// Created by h1ddengames

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace h1ddengames.Enums {
    namespace Blocks {
        [Serializable]
        public class BlockType {
            public static readonly BlockTypeModel BLANK =
                new BlockTypeModel(
                    id: 0, blockName: "BLANK", minBlockLevel: 1, maxBlockLevel: 1, minBlockExperience: 0, maxBlockExperience: 0,
                    minBlockHP: 0, maxBlockHP: 0, minBlockDefense: 0, maxBlockDefense: 0);

            public static readonly BlockTypeModel DIRT =
                new BlockTypeModel(
                    id: 10, blockName: "DIRT", minBlockLevel: 1, maxBlockLevel: 5, minBlockExperience: 1, maxBlockExperience: 10,
                    minBlockHP: 10, maxBlockHP: 20, minBlockDefense: 1, maxBlockDefense: 1);

            public static readonly BlockTypeModel BRONZE =
                new BlockTypeModel(
                    id: 20, blockName: "BRONZE", minBlockLevel: 2, maxBlockLevel: 8, minBlockExperience: 10, maxBlockExperience: 25,
                    minBlockHP: 20, maxBlockHP: 40, minBlockDefense: 10, maxBlockDefense: 20);

            public static readonly BlockTypeModel IRON =
                new BlockTypeModel(
                    id: 30, blockName: "IRON", minBlockLevel: 3, maxBlockLevel: 10, minBlockExperience: 25, maxBlockExperience: 50,
                    minBlockHP: 40, maxBlockHP: 120, minBlockDefense: 20, maxBlockDefense: 30);

            public static readonly BlockTypeModel SILVER =
                new BlockTypeModel(
                    id: 40, blockName: "SILVER", minBlockLevel: 5, maxBlockLevel: 15, minBlockExperience: 50, maxBlockExperience: 100,
                    minBlockHP: 120, maxBlockHP: 300, minBlockDefense: 30, maxBlockDefense: 50);

            public static readonly BlockTypeModel GOLD =
                new BlockTypeModel(
                    id: 50, blockName: "GOLD", minBlockLevel: 8, maxBlockLevel: 20, minBlockExperience: 200, maxBlockExperience: 500,
                    minBlockHP: 300, maxBlockHP: 600, minBlockDefense: 50, maxBlockDefense: 100);

            public static readonly BlockTypeModel RUBY =
                new BlockTypeModel(
                    id: 60, blockName: "RUBY", minBlockLevel: 10, maxBlockLevel: 30, minBlockExperience: 500, maxBlockExperience: 1000,
                    minBlockHP: 600, maxBlockHP: 1000, minBlockDefense: 100, maxBlockDefense: 300);

            public static readonly BlockTypeModel SAPPHIRE =
                new BlockTypeModel(
                    id: 70, blockName: "SAPPHIRE", minBlockLevel: 20, maxBlockLevel: 50, minBlockExperience: 1000, maxBlockExperience: 5000,
                    minBlockHP: 1000, maxBlockHP: 1500, minBlockDefense: 300, maxBlockDefense: 500);

            public static readonly BlockTypeModel EMERALD =
                new BlockTypeModel(
                    id: 80, blockName: "EMERALD", minBlockLevel: 50, maxBlockLevel: 80, minBlockExperience: 5000, maxBlockExperience: 10000,
                    minBlockHP: 1500, maxBlockHP: 3000, minBlockDefense: 500, maxBlockDefense: 1000);

            public static Dictionary<string, BlockTypeModel> ALLBLOCKS = new Dictionary<string, BlockTypeModel>() {
                { BLANK.BlockName, BLANK },
                { DIRT.BlockName, DIRT },
                { BRONZE.BlockName, BRONZE },
                { IRON.BlockName, IRON },
                { SILVER.BlockName, SILVER },
                { GOLD.BlockName, GOLD },
                { RUBY.BlockName, RUBY },
                { SAPPHIRE.BlockName, SAPPHIRE },
                { EMERALD.BlockName, EMERALD }
            };
        }

        [Serializable]
        public class BlockTypeModel {
            [ShowInInspector] public int Id { get; private set; }
            [ShowInInspector] public string BlockName { get; private set; }
            [ShowInInspector] public int MinBlockLevel { get; private set; }
            [ShowInInspector] public int MaxBlockLevel { get; private set; }
            [ShowInInspector] public int MinBlockExperience { get; private set; }
            [ShowInInspector] public int MaxBlockExperience { get; private set; }
            [ShowInInspector] public int MinBlockHP { get; private set; }
            [ShowInInspector] public int MaxBlockHP { get; private set; }
            [ShowInInspector] public int MinBlockDefense { get; private set; }
            [ShowInInspector] public int MaxBlockDefense { get; private set; }

            public BlockTypeModel() { }

            public BlockTypeModel(int id, string blockName,
                            int minBlockLevel, int maxBlockLevel,
                            int minBlockExperience, int maxBlockExperience,
                            int minBlockHP, int maxBlockHP,
                            int minBlockDefense, int maxBlockDefense) {

                Id = id;
                BlockName = blockName;
                MinBlockLevel = minBlockLevel;
                MaxBlockLevel = maxBlockLevel;
                MinBlockExperience = minBlockExperience;
                MaxBlockExperience = maxBlockExperience;
                MinBlockHP = minBlockHP;
                MaxBlockHP = maxBlockHP;
                MinBlockDefense = minBlockDefense;
                MaxBlockDefense = maxBlockDefense;
            }
        }
    }
}