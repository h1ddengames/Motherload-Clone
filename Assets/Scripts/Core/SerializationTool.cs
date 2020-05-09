// Created by h1ddengames

using System.IO;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace h1ddengames.Core {
    public class SerializationTool {
        #region Helper Methods
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
    }
}