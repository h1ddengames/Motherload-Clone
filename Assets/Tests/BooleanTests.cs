// Created by h1ddengames

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using h1ddengames.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class BooleanTests : ToolsTestBaseScript {
        [Test]
        public void BooleanIsAnyOf() {
            string[] strArr = { "hello", "there", "where", "are", "you" };
            List<string> strList = new List<string>() { "hello", "there", "where", "are", "you" };

            int num = 15;
            Assert.IsFalse(num.IsAnyOf(1, 6, 9, 11));

            int num2 = 11;
            Assert.IsTrue(num2.IsAnyOf(1, 6, 9, 11));

            Assert.IsTrue(6.IsAnyOf(1, 6, 9, 11));
            Assert.IsFalse(23.IsAnyOf(1, 6, 9, 11));

            string str = "somereallylongstring";
            Assert.IsFalse(str.IsAnyOf("hello", "there", "why"));

            string str2 = "why";
            Assert.IsTrue(str2.IsAnyOf("hello", "there", "why"));

            Assert.IsTrue("hello".IsAnyOf(strArr));
            Assert.IsTrue("there".IsAnyOf(strList));
            Assert.IsFalse("h9".IsAnyOf(strArr));
            Assert.IsFalse("te".IsAnyOf(strList));
        }

        [Test]
        public void BooleanIsBetween() {
            Assert.IsTrue(23.IsBetween(10, 30));
            Assert.IsFalse(45.IsBetween(5, 10));
            Assert.IsTrue(43.5f.IsBetween(5f, 43.6f));
            Assert.IsFalse(43.5f.IsBetween(5f, 43.4f));
        }
    }
}