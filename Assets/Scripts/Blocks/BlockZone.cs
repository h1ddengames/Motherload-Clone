// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;

namespace h1ddengames.Block {
    [CreateAssetMenu(fileName = "Block Zone", menuName = "h1ddengames/Blocks/New Block Zone")]
    public class BlockZone : SerializedScriptableObject {
        #region Exposed Fields
        [SerializeField] private int lowXPosition; // How far left the blocks should spawn.
        [SerializeField] private int highXPosition; // How far right the blocks should spawn.
        [SerializeField] private int lowYPosition; // How far down the blocks should spawn.
        [SerializeField] private Dictionary<BlockModel, int> blockProbability = new Dictionary<BlockModel, int>();
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        public int LowXPosition { 
            get => lowXPosition; 
            set {
                if(value < -30) { value = -30; }
                if(value > -1) { value = -1; }
                lowXPosition = value; 
            } 
        }
        public int HighXPosition { 
            get => highXPosition; 
            set {
                if(value < 1) { value = 1; }
                if(value > 30) { value = 30; }
                highXPosition = value; 
            } 
        }
        public int LowYPosition { 
            get => lowYPosition; 
            set {
                if(value < 1) {
                    value = 1;
                }
                lowYPosition = value; 
            } 
        }
        #endregion

        #region My Methods
        #endregion

        #region Unity Methods
        private void OnValidate() {
            if(lowXPosition < -30) {
                lowXPosition = -30;
            } else if(lowXPosition > -1) {
                lowXPosition = -1;
            }

            if(highXPosition > 30) {
                highXPosition = 30;
            } else if(highXPosition < 1) {
                highXPosition = 1;
            }

            if(LowYPosition < 1) {
                lowYPosition = 1;
            }

            if(blockProbability.Count < 1) {
                Debug.LogWarning("Please add blocks to the block probability dictionary.");
            }
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}