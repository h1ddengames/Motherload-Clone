// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Unity.RemoteConfig;

namespace h1ddengames.Core {
    public class DebugTool : SerializedMonoBehaviour {
        public struct userAttributes { }
        public struct appAttributes { }

        public static bool allowLog = false;
        public static bool allowWarning = false;
        public static bool allowError = false;

        public static float updateTime = 120f;
        private static float timer = 0f;

        #region Exposed Fields
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        public static void Log(object message) {
            if(allowLog) {
                Debug.Log(message);
            }
        }

        public static void LogWarning(object message) {
            if(allowWarning) {
                Debug.LogWarning(message);
            }
        }

        public static void LogError(object message) {
            if(allowError) {
                Debug.LogError(message);
            }
        }
        #endregion

        #region Unity Methods
        private void Awake() {
            ConfigManager.FetchCompleted += SetDisplayDebugStatements;
            ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        }

        private void SetDisplayDebugStatements(ConfigResponse response) {
            allowLog = ConfigManager.appConfig.GetBool("allowLog");
            allowWarning = ConfigManager.appConfig.GetBool("allowWarning");
            allowError = ConfigManager.appConfig.GetBool("allowError");
        }

        private void Update() {
            timer += Time.deltaTime;

            if(timer > updateTime) {
                timer = 0f;
                ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
                //Log("Updated configs.");
            }
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}