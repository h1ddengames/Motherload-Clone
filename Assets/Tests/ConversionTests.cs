using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using h1ddengames.Extensions;
using NUnit.Framework;

namespace Tests {
    public class ConversionTests : ToolsTestBaseScript {
        #region Conversions
        [Test]
        public void ChangeTypeTest() {
            Assert.AreEqual("123".ChangeType<int>(), 123);
            Assert.AreEqual("123.3".ChangeType<float>(), 123.3f);
            Assert.AreEqual(123.ChangeType<float>(), 123f);
            Assert.AreEqual(10.ToEnum<RarityEnum>().ChangeType<int>(), 10);
        }

        [Test]
        public void ToEnumConvertionFailureTest() {
            var exception = Assert.Throws<ArgumentNullException>(() => 21.ToEnum<RarityEnum>());
            Assert.That(exception.Message, Is.EqualTo("Value cannot be null.\r\nParameter name: value"));
        }

        [Test]
        public void ToEnumConvertionPassTest() {
            Assert.That(0.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.None));
            Assert.That(10.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.Common));
            Assert.That(20.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.Rare));
            Assert.That(30.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.Epic));
            Assert.That(40.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.Unique));
            Assert.That(50.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.Legendary));
            Assert.That(60.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.Ancient));
            Assert.That(70.ToEnum<RarityEnum>(), Is.EqualTo(RarityEnum.OneOfAKind));
        }

        [Test]
        public void EnumNamesToArrayTest() {
            string[] nameArray = Tools.EnumNamesToArray<RarityEnum>();
            int[] valueArray = Tools.EnumValuesToArray<RarityEnum>();

            for(int i = 0; i < nameArray.Length; i++) {

                // Verify that a string can be converted to an enum and that enum is a key in the RarityEnumDictionary.
                // Verify Key exists.
                Assert.AreEqual(true, RarityEnumDictionary.ContainsKey(nameArray[i].ToEnum<RarityEnum>()));

                // Verify that a string can be converted to an enum and that the dictionary contains a Key equal to the converted enum.
                // Verify Key value is the same.
                Assert.AreEqual(nameArray[i].ToEnum<RarityEnum>(), RarityEnumDictionary.Keys.Cast<RarityEnum>().ToArray()[i]);

                // Verify value is the same.
                Assert.AreEqual(valueArray[i], RarityEnumDictionary[nameArray[i].ToEnum<RarityEnum>()]);
            }
        }
        #endregion
    }
}
