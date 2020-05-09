// Created by h1ddengames

using h1ddengames.Block;
using h1ddengames.Enums.Blocks;

namespace h1ddengames.Interfaces {
    namespace Blocks {
        public interface IBlockType {
            IBlockPosition WithBlockType(BlockType blockType);
        }

        public interface IBlockPosition {
            IBlockLevel WithPosition(int xPosition, int yPosition);
        }

        public interface IBlockLevel {
            IBlockExperience WithBlockLevel(int blockLevel);
            IBlockExperience WithBlockLevel(int minBlockLevel, int maxBlockLevel);
        }

        public interface IBlockExperience {
            IBlockHP WithBlockExperience(int blockExperience);
            IBlockHP WithBlockExperience(int minBlockExperience, int maxBlockExperience);
        }

        public interface IBlockHP {
            IBlockDefense WithBlockHP(int blockHP);
            IBlockDefense WithBlockHP(int minBlockHP, int maxBlockHP);
        }

        public interface IBlockDefense {
            IBlockModel WithBlockDefense(int blockDefense);
            IBlockModel WithBlockDefense(int minBlockDefense, int maxBlockDefense);
        }

        public interface IBlockModel {
            BlockModel Finish();
        }
    }


}