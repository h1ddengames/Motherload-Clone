// Created by h1ddengames

using System;
using System.Collections.Generic;

namespace h1ddengames.Enums {
    namespace Blocks {
        public class BlockType {
            public static readonly BlockType BLANK =
                new BlockType(
                    id: 0, "BLANK", minBlockLevel: 1, maxBlockLevel: 1, minBlockExperience: 0, maxBlockExperience: 0,
                    minBlockHP: 0, maxBlockHP: 0, minBlockDefense: 0, maxBlockDefense: 0);

            public static readonly BlockType DIRT =
                new BlockType(
                    id: 10, "DIRT", minBlockLevel: 1, maxBlockLevel: 5, minBlockExperience: 1, maxBlockExperience: 10,
                    minBlockHP: 10, maxBlockHP: 20, minBlockDefense: 1, maxBlockDefense: 1);

            public static readonly BlockType BRONZE =
                new BlockType(
                    id: 20, "BRONZE", minBlockLevel: 2, maxBlockLevel: 8, minBlockExperience: 10, maxBlockExperience: 25,
                    minBlockHP: 20, maxBlockHP: 40, minBlockDefense: 10, maxBlockDefense: 20);

            public static readonly BlockType IRON =
                new BlockType(
                    id: 30, "IRON", minBlockLevel: 3, maxBlockLevel: 10, minBlockExperience: 25, maxBlockExperience: 50,
                    minBlockHP: 40, maxBlockHP: 120, minBlockDefense: 20, maxBlockDefense: 30);

            public static readonly BlockType SILVER =
                new BlockType(
                    id: 40, "SILVER", minBlockLevel: 5, maxBlockLevel: 15, minBlockExperience: 50, maxBlockExperience: 100,
                    minBlockHP: 120, maxBlockHP: 300, minBlockDefense: 30, maxBlockDefense: 50);

            public static readonly BlockType GOLD =
                new BlockType(
                    id: 50, "GOLD", minBlockLevel: 8, maxBlockLevel: 20, minBlockExperience: 200, maxBlockExperience: 500,
                    minBlockHP: 300, maxBlockHP: 600, minBlockDefense: 50, maxBlockDefense: 100);

            public static readonly BlockType RUBY =
                new BlockType(
                    id: 60, "RUBY", minBlockLevel: 10, maxBlockLevel: 30, minBlockExperience: 500, maxBlockExperience: 1000,
                    minBlockHP: 600, maxBlockHP: 1000, minBlockDefense: 100, maxBlockDefense: 300);

            public static readonly BlockType SAPPHIRE =
                new BlockType(
                    id: 70, "SAPPHIRE", minBlockLevel: 20, maxBlockLevel: 50, minBlockExperience: 1000, maxBlockExperience: 5000,
                    minBlockHP: 1000, maxBlockHP: 1500, minBlockDefense: 300, maxBlockDefense: 500);

            public static readonly BlockType EMERALD =
                new BlockType(
                    id: 80, "EMERALD", minBlockLevel: 50, maxBlockLevel: 80, minBlockExperience: 5000, maxBlockExperience: 10000,
                    minBlockHP: 1500, maxBlockHP: 3000, minBlockDefense: 500, maxBlockDefense: 1000);

            public int Id { get; private set; }
            public string BlockName { get; private set; }
            public int MinBlockLevel { get; private set; }
            public int MaxBlockLevel { get; private set; }
            public int MinBlockExperience { get; private set; }
            public int MaxBlockExperience { get; private set; }
            public int MinBlockHP { get; private set; }
            public int MaxBlockHP { get; private set; }
            public int MinBlockDefense { get; private set; }
            public int MaxBlockDefense { get; private set; }

            public BlockType(int id, string blockName,
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

            public static Dictionary<string, BlockType> ALLBLOCKS = new Dictionary<string, BlockType>() {
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
    }
}