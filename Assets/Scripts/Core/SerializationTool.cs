﻿// Created by h1ddengames

using System.IO;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Sirenix.Serialization;

namespace h1ddengames.Core {
    public class SerializationTool : SerializedMonoBehaviour {
        #region Exposed Fields
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        public void Start() {
            //Debug.Log($"{Application.persistentDataPath}");
        }

        public static bool SaveDataToFile<T>(string fileNameWithExtension, T data) {
            if(string.IsNullOrEmpty(fileNameWithExtension)) {
                Debug.Log("Filename is empty or null.");
                return false;
            }

            byte[] bytes = SerializationUtility.SerializeValue(data, DataFormat.JSON);
            File.WriteAllBytes($"{Application.persistentDataPath}/{fileNameWithExtension}", bytes);
            return true;
        }

        public static T LoadDataFromFile<T>(string fileNameWithExtension) {
            byte[] bytes = File.ReadAllBytes($"{Application.persistentDataPath}/{fileNameWithExtension}");
            return SerializationUtility.DeserializeValue<T>(bytes, DataFormat.JSON);
        }
        #endregion

        #region Unity Methods
        #endregion

        #region Helper Methods
        #endregion
    }
}