// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;

namespace h1ddengames {
    public class Splash : MonoBehaviour {
        #region Exposed Fields
        public ModalWindowManager modalWindow;
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        #endregion

        #region Unity Methods
        private void Start() {
            modalWindow.OpenWindow();
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}