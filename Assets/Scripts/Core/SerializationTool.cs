// Created by h1ddengames

using System;
using System.IO;

using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Sirenix.Serialization;
using Sirenix.Utilities;

namespace h1ddengames {
    public class SerializationTool : SerializedMonoBehaviour {
        #region Exposed Fields
        public string savePath = $"C:\\Work\\Projects\\C#\\Motherload-Clone\\Temp\\save.txt";
        public byte[] bytesAsBytesArray;
        public EntityStats stats = new EntityStats();
        public ImprovedEntityStats improvedStats = new ImprovedEntityStats();
        public ImprovedEntityStats otherImprovedStats = new ImprovedEntityStats();
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors

        #endregion

        #region My Methods
        [Button]
        public void SaveState() {
            byte[] bytes = SerializationUtility.SerializeValue(stats, DataFormat.Binary);
            bytesAsBytesArray = bytes;
            Debug.Log(bytes.ToString());
        }

        [Button]
        public void LoadState() {
            stats = SerializationUtility.DeserializeValue<EntityStats>(bytesAsBytesArray, DataFormat.Binary);
        }

        [Button]
        public void SaveStateWithFile() {
            byte[] bytes = SerializationUtility.SerializeValue(stats, DataFormat.Binary);
            File.WriteAllBytes(savePath, bytes);
        }

        [Button]
        public void LoadStateWithFile() {
            byte[] bytes = File.ReadAllBytes(savePath);
            stats = SerializationUtility.DeserializeValue<EntityStats>(bytes, DataFormat.Binary);
        }

        [Button]
        public void AddStats() {
            Debug.Log(improvedStats.hp.GetStat() + otherImprovedStats.hp.GetStat());
        }
        #endregion

        #region Unity Methods
        #endregion

        #region Helper Methods
        #endregion
    }

    public class EntityStats {
        public int hp;
        public int mp;
        public float strength;
        public float intelligence;
        public float luck;
        public float dexterity;
    }

    public class ImprovedEntityStats {
        public Stat<int> hp;
        public Stat<int> mp;
        public Stat<float> strength;
        public Stat<float> intelligence;
        public Stat<float> luck;
        public Stat<float> dexterity;
    }

    public class Stat<T> : IStat<T> {
        public T value;

        public IStat<T> IncrementStat(T amount) {
            GenericMath<T>.Add(value, amount);
            return this;
        }

        public IStat<T> DecrementStat(T amount) {
            GenericMath<T>.Subtract(value, amount);
            return this;
        }

        public T GetStat() {
            return value;
        }

        public IStat<T> SetStat(T value) {
            this.value = value;
            return this;
        }
    }


    public interface IStat<T> {
        IStat<T> IncrementStat(T amount);
        IStat<T> DecrementStat(T amount);
        T GetStat();
        IStat<T> SetStat(T value);
    }

    public class GenericMath<T> {
        public static T Add(T value1, T value2) {
            dynamic a = value1;
            dynamic b = value2;
            return a + b;
        }

        public static T Subtract(T value1, T value2) {
            dynamic a = value1;
            dynamic b = value2;
            return a - b;
        }

        public static T Multiply(T value1, T value2) {
            dynamic a = value1;
            dynamic b = value2;
            return a * b;
        }

        public static T Divide(T value1, T value2) {
            dynamic a = value1;
            dynamic b = value2;
            return a / b;
        }
    }
}