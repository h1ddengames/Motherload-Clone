// Created by h1ddengames

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading;
using Random = System.Random;

namespace h1ddengames.Extensions {
    public static class Tools {
        #region Pubic Fields
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        #endregion

        #region Helper Methods
        #region Random Collection Value
        // Validated. Usage: Tools.GetRandomEnumValue<RarityEnum>();
        public static T GetRandomEnumValue<T>() {
            var enumValues = Enum.GetValues(typeof(T));
            return (T) enumValues.GetValue(GetRandomInt(enumValues.Length));
        }

        // Validated. Usage: RarityEnumArray.GetRandomValue();
        public static T GetRandomValue<T>(this T[] array) => array[GetRandomInt(0, array.Length)];

        // Validated. Usage: RarityEnumList.GetRandomValue();
        public static T GetRandomValue<T>(this List<T> list) => list[GetRandomInt(0, list.Count)];

        // Validated. Usage: RarityEnumDictionary.GetRandomKey();
        public static T2 GetRandomValue<T1, T2>(this Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Value;

        // Validated. Usage: RarityEnumDictionary.GetRandomValue();
        public static T1 GetRandomKey<T1, T2>(this Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Key;

        // Validated. Usage: "somelongstringherecangeneratearandomcharacter".GetRandomValue();
        public static string GetRandomValue(this string str) => str[GetRandomInt(0, str.Length)].ToString();

        // Validated. Usage: 1679654984.GetRandomValue();
        public static int GetRandomValue(this int value) => int.Parse(value.ToString()[GetRandomInt(0, value.ToString().Length)].ToString());
        #endregion

        #region Random Value
        // Validated. Usage: Tools.GetRandomInt();
        public static int GetRandomInt() => random.Value.Next();

        // Validated. Usage: Tools.GetRandomInt(5000000);
        public static int GetRandomInt(int max) => random.Value.Next(max);

        // Validated. Usage: Tools.GetRandomInt(25, 50);
        public static int GetRandomInt(int min, int max) => random.Value.Next(min, max);

        // Validated. Usage: Tools.GetRandomFloat();
        public static float GetRandomFloat() {
            float first = random.Value.Next();
            float second = random.Value.Next();

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }

        // Validated. Usage: Tools.GetRandomFloat(50);
        public static float GetRandomFloat(int max) {
            float first = random.Value.Next(max);
            float second = random.Value.Next(max);

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }

        // Validated. Usage: Tools.GetRandomFloat(25, 50);
        public static float GetRandomFloat(int min, int max) {
            float first = random.Value.Next(min, max);
            float second = random.Value.Next(min, max);

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }

        // Not Validated. Usage: 13.2354667.ToDecimalPlaces(3); --> 13.235
        public static float ToDecimalPlaces(this float value, decimal places) {
            if(places > 1) {
                string[] arr = value.ToString().Split('.');
                StringBuilder decimalPart = new StringBuilder();

                if(arr[1].Length >= places) {
                    for(int i = 0; i < places; i++) {
                        decimalPart.Append(arr[1].ToCharArray()[i]);
                    }
                } else {
                    for(int i = 0; i < arr[1].Length - 1; i++) {
                        decimalPart.Append(arr[1].ToCharArray()[i]);
                    }
                }

                return float.Parse(arr[0] + "." + decimalPart.ToString());
            } else {
                return value;
            }
        }
        #endregion

        #region Data Generator
        // Random People Names

        // Random Location Names

        // Random Item Names

        public static string GetRandomAlphaString(int length) {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".BuildRandomString(length);
        }

        public static string GetRandomAlphaNumericString(int length) {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".BuildRandomString(length);
        }

        public static string GetRandomSpecialCharacterString(int length) {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^&*?()[]{}<>.,;:_+-=|/\\\'\"".BuildRandomString(length);
        }

        public static int GetRandomNumber(int length) => int.Parse("1234567890".BuildRandomString(length));

        public static string BuildRandomString(this string str, int length) {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < length; i++) {
                builder.Append(str[GetRandomInt(0, str.Length)].ToString());
            }
            return builder.ToString();
        }

        public static int BuildRandomNumber(this int value) => int.Parse(value.ToString()[GetRandomInt(0, value.ToString().Length)].ToString());
        #endregion

        #region Boolean
        // if(reallyLongIntegerVariableName == 1 || reallyLongIntegerVariableName == 6 || reallyLongIntegerVariableName == 9 || reallyLongIntegerVariableName == 11) { // do something ... }
        // if(reallyLongIntegerVariableName.IsAnyOf(1,6,9,11)) { // do something ...}
        // if(reallyLongStringVariableName.IsAnyOf("string1","string2","string3")) { // do something ...}
        public static bool IsAnyOf<T>(this T source, params T[] array) {
            if(null == source) throw new ArgumentNullException("source");
            return array.Contains(source);
        }

        // if (myNumber.Between(3,7)) { // do something ... }
        public static bool IsBetween<T>(this T actual, T lower, T upper) where T : IComparable<T> {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
        #endregion

        #region Converters
        // Validated. Usage: int i = "123".ChangeType<int>(); --> "123" (string) becomes 123 (int)
        public static T ChangeType<T>(this object obj) where T : IConvertible {
            return (T) Convert.ChangeType(obj, typeof(T));
        }

        // NEED TO FIX
        public static T ToEnum<T>(this string value) {
            if(value == null) {
                Debug.Log("Returning null");
                throw new ArgumentNullException(value);
            } else {
                Debug.Log("NOT null");
                return (T) Enum.Parse(typeof(T), value, true);
            }
        }

        // NEED TO FIX
        public static T ToEnum<T>(this int value) {
            var name = Enum.GetName(typeof(T), value);
            return name.ToEnum<T>();
        }

        public static string[] EnumNamesToArray<T>() {
            return Enum.GetNames(typeof(T)).ToArray();
        }

        public static int[] EnumValuesToArray<T>() {
            T[] enumArray = (T[]) Enum.GetValues(typeof(T));
            int[] intArray = new int[enumArray.Length];

            for(int i = 0; i < enumArray.Length; i++) {
                intArray[i] = enumArray[i].ChangeType<int>();
            }

            return intArray;
        }

        public static List<T> EnumNamesToList<T>() {
            return Enum.GetNames(typeof(T)).Cast<T>().ToList();
        }

        public static List<T> EnumValuesToList<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static string ToReadableKeys<T1, T2>(this Dictionary<T1, T2> dictionary) {
            return ToReadable(dictionary.Keys.ToArray(), ",");
        }

        public static string ToReadableKeys<T1, T2>(this Dictionary<T1, T2> dictionary, string separator) {
            return ToReadable(dictionary.Keys.ToArray(), separator);
        }

        public static string ToReadableValues<T1, T2>(this Dictionary<T1, T2> dictionary) {
            return ToReadable(dictionary.Values.ToArray(), ",");
        }

        public static string ToReadableValues<T1, T2>(this Dictionary<T1, T2> dictionary, string separator) {
            return ToReadable(dictionary.Values.ToArray(), separator);
        }

        public static string ToReadable<T>(this List<T> list) {
            return ToReadable(list, ",");
        }

        public static string ToReadable<T>(this List<T> list, string separator) {
            return ToReadable<T>(list.ToArray(), separator);
        }

        public static string ToReadable<T>(this T[] array) {
            return ToReadable<T>(array, ",");
        }

        public static string ToReadable<T>(this T[] array, string separator) {
            StringBuilder stringBuilder = new StringBuilder();
            if(array.Length > 0) {
                foreach(var item in array) {
                    stringBuilder.Append(item + $"{separator} ");
                }
                return stringBuilder.ToString();
            } else {
                return "";
            }
        }
        #endregion


        #region Unsorted
        // "h1ddengames".Capitalize --> "H1ddengames"
        public static string Capitalize(this string word) {
            return word[0].ToString().ToUpper() + word.Substring(1);
        }

        public static string ReverseString(this string str) {
            if (string.IsNullOrEmpty(str)) return str;

            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        // allowAdd = true
        // peopleList.AddIf(allowAdd, "h1ddengames");
        public static void AddIf<T>(this ICollection<T> collection, Func<bool> predicate, T item) {
            if(predicate.Invoke()) {
                collection.Add(item);
            }
        }

        // People.AddIf(p => p.Age >= 8, person);
        public static void AddIf<T>(this ICollection<T> collection, Func<T, bool> predicate, T item) {
            if(predicate.Invoke(item))
                collection.Add(item);
        }
        #endregion

        #region Timer
        // Using:
        // Debug.Log($"Run time: { elapsedTime} generated {blockModels.Count}");
        public static string Timer(Action action) {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            action?.Invoke();

            stopWatch.Stop();
            System.TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            return elapsedTime;
        }

        public static string Timer<T>(Action<T> action, T input) {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            action?.Invoke(input);

            stopWatch.Stop();
            System.TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            return elapsedTime;
        }
        #endregion
        #endregion
    }
}