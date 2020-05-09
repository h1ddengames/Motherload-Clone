// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using h1ddengames.Block;
using h1ddengames.Core;

namespace h1ddengames {
    public class SerializationToolTest : SerializedMonoBehaviour {
        #region Exposed Fields
        public BlockModel model;
        public List<BlockModel> models = new List<BlockModel>();
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        [Button]
        public void SaveTestSingle() {
            if(SerializationTool.SaveDataToFile<BlockModel>("save.txt", model)) {
                Debug.Log("Saved Successful.");
            } else {
                Debug.Log("Save failed.");
            }
        }

        [Button]
        public void SaveTestList() {
            if(SerializationTool.SaveDataToFile<List<BlockModel>>("save.txt", models)) {
                Debug.Log("Save Successful.");
            } else {
                Debug.Log("Save failed.");
            }
        }

        [Button]
        public void LoadTestSingle() {
            model = SerializationTool.LoadDataFromFile<BlockModel>("save.txt");
        }

        [Button]
        public void LoadTestList() {
            models = SerializationTool.LoadDataFromFile<List<BlockModel>>("save.txt");
        }
        #endregion

        #region Unity Methods
        #endregion

        #region Helper Methods
        #endregion
    }
}