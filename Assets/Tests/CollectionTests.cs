using System.Collections;
using System.Collections.Generic;
using System.Linq;
using h1ddengames.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class CollectionTests : ToolsTestBaseScript {
        #region Random Collection Value
        [Test]
        public void GetRandomEnumValueTest() {
            Assert.AreEqual(true, RarityEnumArray.Contains(Tools.GetRandomEnumValue<RarityEnum>().ToString()));
        }

        [Test]
        public void GetRandomArrayValueTest() {
            for(int i = 0; i < iterations; i++) {
                string value = RarityEnumArray.GetRandomValue();
                Debug.Log($"GetRandomArrayValueTest : {value}");
                Assert.NotNull(value);
            }
        }

        [Test]
        public void GetRandomListValueTest() {
            for(int i = 0; i < iterations; i++) {
                string value = RarityEnumList.GetRandomValue();
                Debug.Log($"GetRandomListValueTest : {value}");
                Assert.NotNull(value);
            }
        }

        [Test]
        public void GetRandomDictionaryKeyTest() {
            for(int i = 0; i < iterations; i++) {
                RarityEnum value = RarityEnumDictionary.GetRandomKey();
                Debug.Log($"GetRandomDictionaryKeyTest : {value}");
                Assert.NotNull(value);
            }
        }

        [Test]
        public void GetRandomDictionaryValueTest() {
            for(int i = 0; i < iterations; i++) {
                int value = RarityEnumDictionary.GetRandomValue();
                Debug.Log($"GetRandomDictionaryValueTest : {value}");
                Assert.NotNull(value);
            }
        }

        [Test]
        public void GetRandomStringCharacter() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log("somelongstringherecangeneratearandomcharacter".GetRandomValue());
            }
        }

        [Test]
        public void GetRandomInteger() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(1679654984.GetRandomValue());
            }
        }
        #endregion
    }
}
