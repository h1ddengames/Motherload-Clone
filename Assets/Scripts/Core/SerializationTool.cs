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
        public List<EntityStats> allStats = new List<EntityStats>();
        public EntityStats stats = new EntityStats();
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
            byte[] bytes = SerializationUtility.SerializeValue(allStats, DataFormat.JSON);
            File.WriteAllBytes(fullSavePath, bytes);
        }

        [Button]
        public void LoadStateWithFile() {
            string fullSavePath = $"{Application.persistentDataPath}/{savePath}";
            byte[] bytes = File.ReadAllBytes(fullSavePath);
            allStats = SerializationUtility.DeserializeValue<List<EntityStats>>(bytes, DataFormat.JSON);
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
}