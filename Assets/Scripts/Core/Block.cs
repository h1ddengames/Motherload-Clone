// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;

namespace h1ddengames {
    public class Block : SerializedMonoBehaviour {
        #region Exposed Fields
        [SerializeField] private Sprite blockSprite;
        [SerializeField] private int blockLevel;
        [SerializeField] private int blockExperience;
        [SerializeField] private float timeToDestroy;
        [SerializeField] private AudioClip blockDestructionAudioClip;
        #endregion

        #region Private Fields
        private SpriteRenderer blockSpriteRenderer;
        private AudioSource blockAudioSource;
        private Animator blockAnimator;
        #endregion

        #region Getters/Setters/Constructors
        public int BlockLevel { 
            get => blockLevel; 
            set {
                if(value < 1) {
                    value = 1;
                    Debug.LogError($"Block level was set lower than {value}.");
                }

                if(value > 100) {
                    value = 100;
                    Debug.LogError($"Block level was set higher than {value}.");
                }

                blockLevel = value; 
            } 
        }

        public int BlockExperience { 
            get => blockExperience;
            set {
                if(value < -999999) {
                    value = -999999;
                    Debug.LogError($"Block experience was set lower than {value}.");
                }

                if(value > 999999) {
                    value = 999999;
                    Debug.LogError($"Block experience was set higher than {value}.");
                }

                blockExperience = value; 
            }
        }

        #endregion

        #region My Methods
        public void OnBlockDestroyed() {
            if(blockDestructionAudioClip != null) {
                blockAudioSource.Play();
            }

            blockAnimator.SetTrigger("destroyed");
        }
        #endregion

        #region Unity Methods
        private void Start() {
            if(blockSprite == null) {
                Debug.LogError("Sprite reference is missing.");
            }

            if(blockSpriteRenderer == null) {
                blockSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            }

            if(blockSpriteRenderer.sprite == null) {
                blockSpriteRenderer.sprite = blockSprite;
            }

            if(blockAudioSource == null) {
                blockAudioSource = GetComponent<AudioSource>();

                if(blockAudioSource != null && blockDestructionAudioClip != null) {
                    blockAudioSource.clip = blockDestructionAudioClip;
                }
            }            
            
            if(blockAnimator == null) {
                blockAnimator = GetComponent<Animator>();
            }
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}