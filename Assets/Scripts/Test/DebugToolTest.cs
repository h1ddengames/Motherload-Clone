// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using h1ddengames.Core;

namespace h1ddengames.Test {
    public class DebugToolTest : MonoBehaviour {
        #region Exposed Fields
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        #endregion

        #region Unity Methods
        private void Update() {
            DebugTool.Log("Log");
            DebugTool.LogError("Error");
            DebugTool.LogWarning("Warning");
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}