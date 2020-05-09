// Created by h1ddengames

using System;
using UnityEngine;
using h1ddengames.Enums.Blocks;

namespace h1ddengames.Block {
    [Serializable]
    public class BlockModel {
        #region Exposed Fields
        [SerializeField] private BlockType blockType;
        [SerializeField] private int xPosition;
        [SerializeField] private int yPosition;
        [SerializeField] private int blockLevel;
        [SerializeField] private int minBlockLevel;
        [SerializeField] private int maxBlockLevel;
        [SerializeField] private int blockExperience;
        [SerializeField] private int minBlockExperience;
        [SerializeField] private int maxBlockExperience;
        [SerializeField] private int blockHP;
        [SerializeField] private int minBlockHP;
        [SerializeField] private int maxBlockHP;
        [SerializeField] private int blockDefense;
        [SerializeField] private int minBlockDefense;
        [SerializeField] private int maxBlockDefense;
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        public BlockModel() { }

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

        public BlockType BlockType { get => blockType; set => blockType = value; }
        public int XPosition { get => xPosition; set => xPosition = value; }
        public int YPosition { get => yPosition; set => yPosition = value; }
        public int MinBlockLevel { get => minBlockLevel; set => minBlockLevel = value; }
        public int MaxBlockLevel { get => maxBlockLevel; set => maxBlockLevel = value; }
        public int MinBlockExperience { get => minBlockExperience; set => minBlockExperience = value; }
        public int MaxBlockExperience { get => maxBlockExperience; set => maxBlockExperience = value; }
        public int BlockHP { get => blockHP; set => blockHP = value; }
        public int MinBlockHP { get => minBlockHP; set => minBlockHP = value; }
        public int MaxBlockHP { get => maxBlockHP; set => maxBlockHP = value; }
        public int BlockDefense { get => blockDefense; set => blockDefense = value; }
        public int MinBlockDefense { get => minBlockDefense; set => minBlockDefense = value; }
        public int MaxBlockDefense { get => maxBlockDefense; set => maxBlockDefense = value; }
        #endregion

        #region My Methods
        #endregion

        #region Unity Methods
        #endregion

        #region Helper Methods
        #endregion
    }
}