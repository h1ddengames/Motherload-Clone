
using System;
using System.Collections.Generic;

namespace Tests {
    public class ToolsTestBaseScript {
        public int iterations = 50;

        public enum RarityEnum {
            None = 0,
            Common = 10,
            Rare = 20,
            Epic = 30,
            Unique = 40,
            Legendary = 50,
            Ancient = 60,
            OneOfAKind = 70
        }

        public Dictionary<RarityEnum, int> RarityEnumDictionary = new Dictionary<RarityEnum, int>() {
            { RarityEnum.None, 0},
            { RarityEnum.Common, 10 },
            { RarityEnum.Rare, 20 },
            { RarityEnum.Epic, 30 },
            { RarityEnum.Unique, 40},
            { RarityEnum.Legendary, 50 },
            { RarityEnum.Ancient, 60 },
            { RarityEnum.OneOfAKind, 70 }
        };

        public string[] RarityEnumArray = new string[] {
            "None", "Common", "Rare", "Epic", "Unique", "Legendary", "Ancient", "OneOfAKind"
        };

        public List<string> RarityEnumList = new List<string>() {
            "None", "Common", "Rare", "Epic", "Unique", "Legendary", "Ancient", "OneOfAKind"
        };
    }
}
