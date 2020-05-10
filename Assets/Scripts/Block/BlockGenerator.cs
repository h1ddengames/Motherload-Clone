// Created by h1ddengames

using System.Threading;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
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

        [SerializeField] private Dictionary<Sprite, AudioClip> spritesAndAudioClips = new Dictionary<Sprite, AudioClip>();
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        public void GenerateBlockZone(BlockZone blockZone, int offset) {
            Debug.Log(
                $"Left: {blockZone.LowXPosition} " +
                $"Right: { blockZone.HighXPosition } " +
                $"Depth: { blockZone.LowYPosition } " +
                $"Current Offset: { offset }");

            // Adding +1 to the offset so that the next blockzone doesn't overlap with the last row of the last blockzone.
            for(int yPosition = offset + 1; yPosition <= offset + blockZone.LowYPosition; yPosition++) {
                for(int xPosition = blockZone.LowXPosition; xPosition <= blockZone.HighXPosition; xPosition++) {
                    //Debug.Log($"({xPosition}, {yPosition})");
                    blockModels.Add(
                        BlockModelFactory
                        .Start()
                        .WithBlockType()
                        .WithPosition(xPosition, yPosition)
                        .WithBlockLevelFromBlockType()
                        .WithBlockExperienceFromBlockType()
                        .WithBlockHPFromBlockType()
                        .WithBlockDefenseFromBlockType()
                        .Finish()
                    );
                }
            }
        }

        [Button]
        public void MultithreadedBlockZoneGenerator() {
            int offset = -1;

            blockModels.Clear();

            foreach(var blockZone in blockZones) {

                var blockZoneReporter = new Thread(() => GenerateBlockZone(blockZone, offset));
                blockZoneReporter.Start();

                offset += blockZone.LowYPosition;
            }

            SerializationTool.SaveDataToFile<List<BlockModel>>("save.txt", blockModels);
        }

        [Button]
        public void MultithreadedBlockZoneGeneratorTimed() {
            Debug.Log($"Run time: { Tools.Timer(MultithreadedBlockZoneGenerator) } generated {blockModels.Count}");
        }

        //[Button]
        //public void GenerateBlocks() {
        //    RemoveAllBlocks();

        //    int additionalDepth = 0;

        //    GameObject blockGameObject;
        //    Block block;
        //    Sprite sprite;

        //    for(int currentBlockZone = 0; currentBlockZone < listOfBlockZones.Count; currentBlockZone++) {
        //        GameObject zoneHolder = new GameObject("Zone " + currentBlockZone);
        //        zoneHolder.transform.SetParent(transform);

        //        if(currentBlockZone != 0) {
        //            additionalDepth += listOfBlockZones[currentBlockZone - 1].depth;
        //        }

        //        for(int currentYPosition = 0; currentYPosition < listOfBlockZones[currentBlockZone].depth; currentYPosition++) {
        //            for(int currentXPosition = listOfBlockZones[currentBlockZone].leftEdge; currentXPosition < listOfBlockZones[currentBlockZone].rightEdge; currentXPosition++) {
        //                sprite = WeightedRandomizer.From(listOfBlockZones[currentBlockZone].BlockProbability).TakeOne();

        //                if(!sprite.name.Contains("blank")) {
        //                    blockGameObject = Instantiate(blockPrefab, new Vector2(currentXPosition, -currentYPosition - additionalDepth), Quaternion.identity, zoneHolder.transform);

        //                    block = blockGameObject.GetComponent<Block>();
        //                    block.blockSpriteRenderer.sprite = sprite;
        //                    block.AssignSpriteToBlock();

        //                    listOfBlocks.Add(blockGameObject);
        //                }
        //            }
        //        }
        //    }
        //}

        //[Button]
        //public void RemoveAllBlocks() {
        //    for(int i = 0; i < transform.childCount;) {
        //        if(transform.childCount > 0) {
        //            DestroyImmediate(transform.GetChild(i).gameObject);
        //            i = 0;
        //        } else {
        //            i++;
        //        }
        //    }

        //    listOfBlocks.Clear();
        //}

        //// 200 Blocks = -10 x, 10 y, 10 d, 3 ms
        //// 2000 Blocks = -10 x, 10 y, 100 d, 43 ms
        //// 20000 Blocks = -10 x, 10 y, 1000 d, 4.5 s
        //// 200000 Blocks = -10 x, 10 y, 10000 d, 54 s
        //public void GenerateTimedTest() {
        //    System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        //    stopWatch.Start();

        //    GenerateBlocks();

        //    stopWatch.Stop();
        //    System.TimeSpan ts = stopWatch.Elapsed;
        //    string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //        ts.Hours, ts.Minutes, ts.Seconds,
        //        ts.Milliseconds / 10);
        //    Debug.Log($"Run time: { elapsedTime} generated {listOfBlocks.Count}");
        //}
        #endregion

        #region Unity Methods
        private void Start() {

        }
        #endregion

        #region Helper Methods
        #endregion
    }
}