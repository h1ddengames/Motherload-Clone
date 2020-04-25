// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;

namespace h1ddengames.Unsorted {
    public class Splash : MonoBehaviour {
        #region Exposed Fields
        public ModalWindowManager splashModalWindow;
        public ModalWindowManager quitModalWindow;
        #endregion

        #region Private Fields
        #endregion

        #region Getters/Setters/Constructors
        #endregion

        #region My Methods
        public void Quit() {
            Application.Quit(0);
        }
        #endregion

        #region Unity Methods
        private void Start() {
            splashModalWindow.gameObject.SetActive(true);
            splashModalWindow.OpenWindow();
            quitModalWindow.gameObject.SetActive(false);
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                quitModalWindow.gameObject.SetActive(true);
                quitModalWindow.OpenWindow();
            }
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}