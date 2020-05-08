// Created by h1ddengames

using System;
using System.IO;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Sirenix.Serialization;

namespace h1ddengames {
    public class SerializationTool : SerializedMonoBehaviour {
        #region Exposed Fields
        public string savePath = "save.txt";
        //public List<EntityStats> allStats = new List<EntityStats>();
        //public EntityStats stats = new EntityStats();

        public List<BlockModel> blocks = new List<BlockModel>();

        [SerializeField] private Dictionary<Sprite, AudioClip> spritesAndAudioClips = new Dictionary<Sprite, AudioClip>();
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        public void Start() {
            Debug.Log($"{Application.persistentDataPath}/{savePath}");
        }

        [Button]
        public void SaveStateWithFile() {
            if(string.IsNullOrEmpty(savePath)) {
                savePath = "save.txt";
            }

            string fullSavePath = $"{Application.persistentDataPath}/{savePath}";
            byte[] bytes = SerializationUtility.SerializeValue(blocks, DataFormat.JSON);
            File.WriteAllBytes(fullSavePath, bytes);
        }

        [Button]
        public void LoadStateWithFile() {
            string fullSavePath = $"{Application.persistentDataPath}/{savePath}";
            byte[] bytes = File.ReadAllBytes(fullSavePath);
            blocks = SerializationUtility.DeserializeValue<List<BlockModel>>(bytes, DataFormat.JSON);
        }
        #endregion

        #region Unity Methods
        #endregion

        #region Helper Methods
        #endregion
    }

    [Serializable]
    public class EntityStats {
        public int hp;
        public int mp;
        public float strength;
        public float intelligence;
        public float luck;
        public float dexterity;
        public int min;
        public int max;
        public bool isSet;
    }

    public enum BlockType {
        Blank = 0,
        Dirt = 10,
        Bronze = 20,
        Iron = 30,
        Silver = 40,
        Gold = 50,
        Ruby = 60,
        Sapphire = 70,
        Emerald = 80
    }

    [Serializable]
    public class BlockModel {
        [SerializeField] private BlockType blockType;
        [SerializeField] private int xPosition;
        [SerializeField] private int yPosition;
        [SerializeField] private int blockLevel;
        [SerializeField] private int minBlockLevel;
        [SerializeField] private int maxBlockLevel;
        [SerializeField] private int blockExperience;
        [SerializeField] private int minBlockExperience;
        [SerializeField] private int maxBlockExperience;
        [SerializeField] private float timeToDestroy;

        public int BlockLevel {
            get => blockLevel;
            set {
                if(value < 1) {
                    value = 1;
                    Debug.LogError($"Block level was set lower than {value}.");
                }

                if(value > 100) {
                    value = 100;
                    Debug.LogError($"Block level was set higher than {value}.");
                }

                blockLevel = value;
            }
        }

        public int BlockExperience {
            get => blockExperience;
            set {
                if(value < -999999) {
                    value = -999999;
                    Debug.LogError($"Block experience was set lower than {value}.");
                }

                if(value > 999999) {
                    value = 999999;
                    Debug.LogError($"Block experience was set higher than {value}.");
                }

                blockExperience = value;
            }
        }
    }
}