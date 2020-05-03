// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;
using UnityEngine;

namespace h1ddengames.Block {
    public class Block : SerializedMonoBehaviour {
        #region Exposed Fields
        [SerializeField] private BlockModel blockModel;
        #endregion

        #region Private Fields
        private SpriteRenderer blockSpriteRenderer;
        private AudioSource blockAudioSource;
        private Animator blockAnimator;
        #endregion

        #region Getters/Setters/Constructors
        public BlockModel BlockModel { get => blockModel; set => blockModel = value; }
        #endregion

        #region My Methods
        public void OnBlockDestroyed() {
            if(BlockModel.BlockDestructionAudioClip != null) {
                blockAudioSource.Play();
            }

            blockAnimator.SetTrigger("destroyed");
        }
        #endregion

        #region Unity Methods
        private void Start() {
            if(BlockModel.BlockSprite == null) {
                Debug.LogError("Sprite reference is missing.");
            }

            if(blockSpriteRenderer == null) {
                blockSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            }

            if(blockSpriteRenderer.sprite == null) {
                blockSpriteRenderer.sprite = BlockModel.BlockSprite;
            }

            if(blockAudioSource == null) {
                blockAudioSource = GetComponent<AudioSource>();

                if(blockAudioSource != null && BlockModel.BlockDestructionAudioClip != null) {
                    blockAudioSource.clip = BlockModel.BlockDestructionAudioClip;
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

    [Serializable]
    public class BlockModel {
        [SerializeField] private Sprite blockSprite;
        [SerializeField] private int blockLevel;
        [SerializeField] private Vector2 blockLevelRandomness;
        [SerializeField] private int blockExperience;
        [SerializeField] private Vector2 blockExperienceRandomness;
        [SerializeField] private float timeToDestroy;
        [SerializeField] private AudioClip blockDestructionAudioClip;

        #region Getters/Setters/Constructors
        public Sprite BlockSprite { get => blockSprite; set => blockSprite = value; }

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

        public float TimeToDestroy { get => timeToDestroy; set => timeToDestroy = value; }
        public AudioClip BlockDestructionAudioClip { get => blockDestructionAudioClip; set => blockDestructionAudioClip = value; }
        public Vector2 BlockLevelRandomness { get => blockLevelRandomness; set => blockLevelRandomness = value; }
        public Vector2 BlockExperienceRandomness { get => blockExperienceRandomness; set => blockExperienceRandomness = value; }
        #endregion
    }
}