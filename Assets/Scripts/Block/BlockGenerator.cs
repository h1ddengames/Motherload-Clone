// Created by h1ddengames

using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using h1ddengames.Factories.Blocks;
using h1ddengames.Core;
using h1ddengames.Extensions;

namespace h1ddengames.Block {
    public class BlockGenerator : SerializedMonoBehaviour {
        #region Exposed Fields
        public GameObject blockPrefab;

        public List<GameObject> blocks = new List<GameObject>();
        public List<BlockModel> blockModels = new List<BlockModel>();
        public List<BlockZone> blockZones = new List<BlockZone>();
        [SerializeField] public Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();
        [SerializeField] private Dictionary<Sprite, AudioClip> spritesAndAudioClips = new Dictionary<Sprite, AudioClip>();
        //public List<BlockModel> generateThisRow = new List<BlockModel>();
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        public void GenerateBlockZone(BlockZone blockZone, int offset) {
            // Adding +1 to the offset so that the next blockzone doesn't overlap with the last row of the last blockzone.
            for(int yPosition = offset + 1; yPosition <= offset + blockZone.LowYPosition; yPosition++) {
                for(int xPosition = blockZone.LowXPosition; xPosition <= blockZone.HighXPosition; xPosition++) {
                    BlockModel model =
                        BlockModelFactory
                        .Start()
                        .WithBlockType(WeightedRandomizer.From(blockZone.BlockProbability).TakeOne())
                        .WithPosition(xPosition, yPosition)
                        .WithBlockLevelFromBlockType()
                        .WithBlockExperienceFromBlockType()
                        .WithBlockHPFromBlockType()
                        .WithBlockDefenseFromBlockType()
                        .Finish();

                    //Debug.Log($"{model.BlockType.BlockName}");
                    if(model.BlockType.BlockName != "BLANK") {
                        blockModels.Add(model);
                    }
                }
            }
        }

        // Generates 2500 in 3 ms           --- Improvement from singe threaded version: 200 blocks in 3 ms
        // Generates 30000 in 43 ms         --- Improvement from singe threaded version: 20000 blocks in 43 ms
        // Generates 350000 in 4.5 s        --- Improvement from singe threaded version: 200000 blocks in 54 s
        [Button]
        public void MultithreadedBlockZoneGenerator() {
            int offset = -1;

            blockModels.Clear();

            foreach(var blockZone in blockZones) {
                if(blockZone != null) {
                    var blockZoneReporter = new Thread(() => GenerateBlockZone(blockZone, offset));
                    blockZoneReporter.Start();

                    // Required to make sure the same amount of blocks are generated each time.
                    blockZoneReporter.Join();

                    offset += blockZone.LowYPosition;
                }
            }

            // Saves BlockModel list data to C:\Users\hiddengames\AppData\LocalLow\hiddengames\Motherload-Clone
            SerializationTool.SaveDataToFile("save.txt", blockModels);
        }

        [Button]
        public void MultithreadedBlockZoneGeneratorTimed() {
            Debug.Log($"Run time: { Tools.Timer(MultithreadedBlockZoneGenerator) } generated {blockModels.Count}");

            Debug.Log($"Sorting time: { Tools.Timer(OrderList) }");

            //generateThisRow.Clear();
            //generateThisRow = blockModels.Where(y => y.YPosition <= 5).ToList();
        }

        [Button]
        public void ClearBlockModelList() => blockModels.Clear();

        public void OrderList() => blockModels = blockModels.OrderBy(y => y.YPosition).ToList();

        [Button]
        public void GenerateBlocks() {
            for(int i = 0; i < 1000; i++) {
                GameObject current = Instantiate(blockPrefab, transform);
                current.transform.position = new Vector2(blockModels[i].XPosition, -blockModels[i].YPosition);
                current.GetComponent<Block>().BlockModel = blockModels[i];

                current.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteDictionary.ValueOf(blockModels[i].BlockTypeString);
            }
        }

        [Button]
        public void RemoveBlocks() {
            for(int i = transform.childCount - 1; i >= 0; i--) {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        #endregion

        #region Unity Methods
        private void Start() {

        }

        private void OnValidate() {
            
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}