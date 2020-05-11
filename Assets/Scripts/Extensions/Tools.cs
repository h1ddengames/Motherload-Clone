// Created by h1ddengames

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace h1ddengames.Extensions {
    public static class Tools {
        #region Pubic Fields
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        #endregion

        #region Helper Methods
        #region Random Collection Value
        // public static T GetRandomArrayValue<T>(T[] array) => array[GetRandomInt(0, array.Length)];
        // public static T GetRandomListValue<T>(List<T> list) => list[GetRandomInt(0, list.Count)];
        // public static T1 GetRandomDictionaryKey<T1, T2>(Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Key;
        // public static T2 GetRandomDictionaryValue<T1, T2>(Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Value;
        // public static string GetRandomCharacter(this string str) => str[GetRandomInt(0, str.Length)].ToString();

        public static T GetRandomEnumValue<T>() {
            var enumValues = Enum.GetValues(typeof(T));
            return (T) enumValues.GetValue(GetRandomInt(enumValues.Length));
        }
        
        public static T GetRandomValue<T>(this T[] array) => array[GetRandomInt(0, array.Length)];

        public static T GetRandomValue<T>(this List<T> list) => list[GetRandomInt(0, list.Count)];

        public static T2 GetRandomValue<T1, T2>(this Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Value;

        public static T1 GetRandomKey<T1, T2>(this Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Key;

        public static string GetRandomValue(this string str) => str[GetRandomInt(0, str.Length)].ToString();
        public static int GetRandomValue(this int value) => int.Parse(value.ToString()[GetRandomInt(0, value.ToString().Length)].ToString());
        #endregion

        #region Random Value
        public static int GetRandomInt() => random.Value.Next();

        public static int GetRandomInt(int max) => random.Value.Next(max);

        public static int GetRandomInt(int min, int max) => random.Value.Next(min, max);

        public static float GetRandomFloat() {
            float first = random.Value.Next();
            float second = random.Value.Next();

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }
        #endregion

        #region Data Generator
        //public static string GetRandomString(int length) {
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[GetRandomInt(s.Length)]).ToArray());
        //}

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
        // int i = "123".ChangeType<int>();
        public static T ChangeType<T>(this object obj) {
            return (T) Convert.ChangeType(obj, typeof(T));
        }
        #endregion


        #region Unsorted

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