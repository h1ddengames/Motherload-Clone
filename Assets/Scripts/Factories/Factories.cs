// Created by h1ddengames

using System;
using h1ddengames.Block;
using h1ddengames.Interfaces.Blocks;
using h1ddengames.Enums.Blocks;
using h1ddengames.Extensions;

namespace h1ddengames.Factories {
    namespace Blocks {
        public class BlockModelFactory : IBlockType, IBlockPosition, IBlockLevel, IBlockExperience, IBlockHP, IBlockDefense, IBlockModel {
            public BlockModel blockModel;

            private BlockModelFactory() { blockModel = new BlockModel(); }

            public static IBlockType Start() {
                return new BlockModelFactory();
            }

            public IBlockPosition WithBlockType() {
                blockModel.BlockType = Tools.RandomEnumValue<BlockType>();
                return this;
            }

            public IBlockPosition WithBlockType(BlockType blockType) {
                blockModel.BlockType = blockType;
                return this;
            }

            public IBlockLevel WithPosition(int xPosition, int yPosition) {
                blockModel.XPosition = xPosition;
                blockModel.YPosition = yPosition;
                return this;
            }

            public IBlockExperience WithBlockLevel(int blockLevel) {
                blockModel.BlockLevel = blockLevel;
                return this;
            }

            public IBlockExperience WithBlockLevel(int minBlockLevel, int maxBlockLevel) {
                blockModel.MinBlockLevel = minBlockLevel;
                blockModel.MaxBlockLevel = maxBlockLevel;
                blockModel.BlockLevel = UnityEngine.Random.Range(blockModel.MinBlockLevel, blockModel.MaxBlockLevel);
                return this;
            }

            public IBlockHP WithBlockExperience(int blockExperience) {
                blockModel.BlockExperience = blockExperience;
                return this;
            }

            public IBlockHP WithBlockExperience(int minBlockExperience, int maxBlockExperience) {
                blockModel.MinBlockExperience = minBlockExperience;
                blockModel.MaxBlockExperience = maxBlockExperience;
                blockModel.BlockExperience = UnityEngine.Random.Range(blockModel.MinBlockExperience, blockModel.MaxBlockExperience);
                return this;
            }

            public IBlockDefense WithBlockHP(int blockHP) {
                blockModel.BlockHP = blockHP;
                return this;
            }

            public IBlockDefense WithBlockHP(int minBlockHP, int maxBlockHP) {
                blockModel.MinBlockHP = minBlockHP;
                blockModel.MaxBlockHP = maxBlockHP;
                blockModel.BlockHP = UnityEngine.Random.Range(blockModel.MinBlockHP, blockModel.MaxBlockHP);
                return this;
            }

            public IBlockModel WithBlockDefense(int blockDefense) {
                blockModel.BlockDefense = blockDefense;
                return this;
            }

            public IBlockModel WithBlockDefense(int minBlockDefense, int maxBlockDefense) {
                blockModel.MinBlockDefense = minBlockDefense;
                blockModel.MaxBlockDefense = maxBlockDefense;
                blockModel.BlockDefense = UnityEngine.Random.Range(blockModel.MinBlockDefense, blockModel.MaxBlockDefense);
                return this;
            }

            public BlockModel Finish() {
                return blockModel;
            }
        }
    }


}