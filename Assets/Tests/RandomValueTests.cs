using System.Collections;
using System.Collections.Generic;
using h1ddengames.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class RandomValueTests : ToolsTestBaseScript
    {
        [Test]
        public void RandomIntegerValuesWithoutBounds() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(Tools.GetRandomInt());
            }
        }

        [Test]
        public void RandomIntegerValuesWithMax() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(Tools.GetRandomInt(5000000));
            }
        }

        [Test]
        public void RandomIntegerValuesWithBounds() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(Tools.GetRandomInt(25, 50));
            }
        }

        [Test]
        public void RandomFloatValuesWithoutBounds() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(Tools.GetRandomFloat());
            }
        }

        [Test]
        public void RandomFloatValuesWithMax() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(Tools.GetRandomFloat(50));
            }
        }

        [Test]
        public void RandomFloatValuesWithBounds() {
            for(int i = 0; i < iterations; i++) {
                Debug.Log(Tools.GetRandomFloat(25, 50));
            }
        }

        [Test]
        public void RandomFloatValueWithDecimals() {
            for(int i = 0; i < 5; i++) {
                float f = Tools.GetRandomFloat();
                Debug.Log($"Raw value: {f}");
                Debug.Log($"Modified value: {f.ToDecimalPlaces(1)}");
                Debug.Log("----------------------------------------------------");
            }

            for(int i = 0; i < 5; i++) {
                float f = Tools.GetRandomFloat();
                Debug.Log($"Raw value: {f}");
                Debug.Log($"Modified value: {f.ToDecimalPlaces(2)}");
                Debug.Log("----------------------------------------------------");
            }

            for(int i = 0; i < 5; i++) {
                float f = Tools.GetRandomFloat();
                Debug.Log($"Raw value: {f}");
                Debug.Log($"Modified value: {f.ToDecimalPlaces(3)}");
                Debug.Log("----------------------------------------------------");
            }

            for(int i = 0; i < 5; i++) {
                float f = Tools.GetRandomFloat();
                Debug.Log($"Raw value: {f}");
                Debug.Log($"Modified value: {f.ToDecimalPlaces(4)}");
                Debug.Log("----------------------------------------------------");
            }

            for(int i = 0; i < 5; i++) {
                float f = Tools.GetRandomFloat();
                Debug.Log($"Raw value: {f}");
                Debug.Log($"Modified value: {f.ToDecimalPlaces(5)}");
                Debug.Log("----------------------------------------------------");
            }
        }

        //[Test]
        //public void RandomFloatValuesWithBoundsToOneDecimalPlaces() {
        //    for(int i = 0; i < iterations; i++) {
        //        Debug.Log(Tools.GetRandomFloat(25, 50).ToDecimalPlaces(1));
        //    }
        //}

        //[Test]
        //public void RandomFloatValuesWithBoundsToTwoDecimalPlaces() {
        //    for(int i = 0; i < iterations; i++) {
        //        Debug.Log(Tools.GetRandomFloat(25, 50).ToDecimalPlaces(2));
        //    }
        //}

        //[Test]
        //public void RandomFloatValuesWithBoundsToThreeDecimalPlaces() {
        //    for(int i = 0; i < iterations; i++) {
        //        Debug.Log(Tools.GetRandomFloat(25, 50).ToDecimalPlaces(3));
        //    }
        //}
    }
}
