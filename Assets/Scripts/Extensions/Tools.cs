// Created by h1ddengames

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading;
using Random = System.Random;
using System.Globalization;

namespace h1ddengames.Extensions {
    public static class Tools {
        #region Pubic Fields
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        #endregion

        #region Helper Methods
        #region Random Collection Value
        /// <summary>
        /// Get a random enum value. <para /> 
        /// Usage: Tools.GetRandomEnumValue()&lt;RarityEnum&gt;()
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <returns>A random enum value.</returns>
        public static T GetRandomEnumValue<T>() {
            var enumValues = Enum.GetValues(typeof(T));
            return (T) enumValues.GetValue(GetRandomInt(enumValues.Length));
        }

        /// <summary>
        /// Get a random value from an array. <para />
        /// Usage: RarityEnumArray.GetRandomValue();
        /// </summary>
        /// <typeparam name="T">An array.</typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T GetRandomValue<T>(this T[] array) => array[GetRandomInt(0, array.Length)];

        /// <summary>
        /// Get a random value from a list. <para />
        /// Usage: RarityEnumList.GetRandomValue();
        /// </summary>
        /// <typeparam name="T">A list.</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T GetRandomValue<T>(this List<T> list) => list[GetRandomInt(0, list.Count)];

        /// <summary>
        /// Get a random value from a dictionary. <para />
        /// Usage: RarityEnumDictionary.GetRandomKey();
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static T2 GetRandomValue<T1, T2>(this Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Value;

        /// <summary>
        /// Get a random key from a dictionary. <para />
        /// Usage: RarityEnumDictionary.GetRandomValue();
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static T1 GetRandomKey<T1, T2>(this Dictionary<T1, T2> dictionary) => dictionary.ElementAt(GetRandomInt(0, dictionary.Count)).Key;

        /// <summary>
        /// Get a random character from a given string. <para />
        /// Usage: "somelongstringherecangeneratearandomcharacter".GetRandomValue(); <para />
        /// Usage: string str = "somethinghere"; str.GetRandomValue();
        /// </summary>
        /// <param name="str">The string to choose a character from.</param>
        /// <returns></returns>
        public static string GetRandomValue(this string str) => str[GetRandomInt(0, str.Length)].ToString();

        /// <summary>
        /// Get a random digit from a given integer. <para />
        /// Usage: 1679654984.GetRandomValue();  <para />
        /// Usage: int value = 1223523; value.GetRandomValue();
        /// </summary>
        /// <param name="value">The integer to choose a digit from.</param>
        /// <returns></returns>
        public static int GetRandomValue(this int value) => int.Parse(value.ToString()[GetRandomInt(0, value.ToString().Length)].ToString());
        #endregion

        #region Random Value
        /// <summary>
        /// Get a random integer between integer.MINVALUE and integer.MAXVALUE <para />
        /// Usage: Tools.GetRandomInt();
        /// </summary>
        /// <returns></returns>
        public static int GetRandomInt() => random.Value.Next();

        /// <summary>
        /// Get a random integer between integer.MINVALUE and a given max value. <para />
        /// Usage: Usage: Tools.GetRandomInt(5000000);
        /// </summary>
        /// <returns></returns>
        public static int GetRandomInt(int max) => random.Value.Next(max);

        // Validated. 
        /// <summary>
        /// Get a random integer between a given min value and a given max value. <para />
        /// Usage: Usage: Tools.GetRandomInt(25, 50);
        /// </summary>
        /// <returns></returns>
        public static int GetRandomInt(int min, int max) => random.Value.Next(min, max);
 
        /// <summary>
        /// Get a random float between float.MINVALUE and float.MAXVALUE <para />
        /// Usage: Tools.GetRandomFloat();
        /// </summary>
        /// <returns></returns>
        public static float GetRandomFloat() {
            float first = random.Value.Next();
            float second = random.Value.Next();

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }

        /// <summary>
        /// Get a random float between float.MINVALUE and a given max value. <para />
        /// Usage: Tools.GetRandomFloat(5522200f);
        /// </summary>
        /// <returns></returns>
        public static float GetRandomFloat(int max) {
            float first = random.Value.Next(max);
            float second = random.Value.Next(max);

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }

        /// <summary>
        /// Get a random float between a given min value and a given max value. <para />
        /// Usage: Tools.GetRandomFloat(25, 50);
        /// </summary>
        /// <returns></returns>
        public static float GetRandomFloat(int min, int max) {
            float first = random.Value.Next(min, max);
            float second = random.Value.Next(min, max);

            if(first > second) {
                return second / first;
            } else {
                return first / second;
            }
        }
        #endregion

        #region Data Generator
        // Random People Names

        // Random Location Names

        // Random Item Names

        /// <summary>
        /// Get a string of a given length from these characters: ABCDEFGHIJKLMNOPQRSTUVWXYZ <para />
        /// Usage: Tools.GetRandomAlphaString(5);
        /// </summary>
        /// <param name="length">The length of the expected string.</param>
        /// <returns></returns>
        public static string GetRandomAlphaString(int length) => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".BuildRandomString(length);

        /// <summary>
        /// Get a string of a given length from these characters: ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 <para />
        /// Usage: Tools.GetRandomAlphaNumericString(5);
        /// </summary>
        /// <param name="length">The length of the expected string.</param>
        /// <returns></returns>
        public static string GetRandomAlphaNumericString(int length) => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".BuildRandomString(length);

        /// <summary>
        /// Get a string of a given length from these characters: ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^*?()[]{}&lt;&gt;.,;:_+-=|/\'" <para />
        /// Usage: Tools.GetRandomSpecialCharacterString(5);
        /// </summary>
        /// <param name="length">The length of the expected string.</param>
        /// <returns></returns>
        public static string GetRandomSpecialCharacterString(int length) => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^&*?()[]{}<>.,;:_+-=|/\\\'\"".BuildRandomString(length);

        /// <summary>
        /// Get a random number of a given length. <para />
        /// Usage: Tools.GetRandomNumber(7);
        /// </summary>
        /// <param name="length">The length of the expected number.</param>
        /// <returns></returns>
        public static int GetRandomNumber(int length) => int.Parse("1234567890".BuildRandomString(length));

        /// <summary>
        /// Given a string, build another string of a given length. <para />
        /// Usage: "somerandomstringhere".BuildRandomString(17);
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BuildRandomString(this string str, int length) {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < length; i++) {
                builder.Append(str[GetRandomInt(0, str.Length)].ToString());
            }
            return builder.ToString();
        }
        #endregion

        #region Boolean
        /// <summary>
        /// Check if a value is found in a given array. <para />
        /// Usage: "hello".IsAnyOf(strArr); <para />
        /// Usage: "there".IsAnyOf("hello", "there", "why"); <para />
        /// Usage: 6.IsAnyOf(1, 6, 9, 11);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsAnyOf<T>(this T source, params T[] array) {
            if(null == source) throw new ArgumentNullException("source");
            return array.Contains(source);
        }

        /// <summary>
        /// Check if a value is found in a given list. <para />
        /// List&lt;string&gt; strList = new List&lt;string&gt;() { "hello", "there", "where", "are", "you" }; <para />
        /// Usage: "there".IsAnyOf(strList);  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsAnyOf<T>(this T source, List<T> list) {
            if(null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        // if (myNumber.IsBetween(3,7)) { // do something ... }
        /// <summary>
        /// Check if a value is between a lower limit and a higher limit. <para />
        /// Usage: 23.IsBetween(10, 30) <para />
        /// Usage: 43.5f.IsBetween(5f, 43.6f) <para />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T actual, T lower, T upper) where T : IComparable<T> => actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;

        /// <summary>
        /// Check if a collection is null or empty. <para />
        /// Usage: someCollection.IsNullOrEmpty();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> e) => e == null || e.Count == 0;

        /// <summary>
        /// Check if a string is null or empty. <para />
        /// Usage: str.IsNullOrEmpty();
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str) => str == null || str.Length == 0;
        #endregion

        #region Formatting
        /// <summary>
        /// Format a float value to return a given number of digits after the decimal. Warning: this will remove trailing zeros. <para />
        /// Usage: 13.2354667.ToDecimalPlaces(3); --> 13.235 <para />
        /// Usage: 13.235024522.ToDecimalPlaces(4); --> 13.235 (Removes the trailing zero)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="places"></param>
        /// <returns></returns>
        public static float ToDecimalPlaces(this float value, decimal places) {
            if(places >= 1) {
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

        public static string ToReadableKeys<T1, T2>(this Dictionary<T1, T2> dictionary) => ToReadable(dictionary.Keys.ToArray(), ",");

        public static string ToReadableKeys<T1, T2>(this Dictionary<T1, T2> dictionary, string separator) => ToReadable(dictionary.Keys.ToArray(), separator);

        public static string ToReadableValues<T1, T2>(this Dictionary<T1, T2> dictionary) => ToReadable(dictionary.Values.ToArray(), ",");

        public static string ToReadableValues<T1, T2>(this Dictionary<T1, T2> dictionary, string separator) => ToReadable(dictionary.Values.ToArray(), separator);

        public static string ToReadable<T>(this List<T> list) => ToReadable(list, ",");

        public static string ToReadable<T>(this List<T> list, string separator) => ToReadable<T>(list.ToArray(), separator);

        public static string ToReadable<T>(this T[] array) => ToReadable<T>(array, ",");

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

        #region REQUIRES FURTHER TEST
        public static T As<T>(this object value) => (value != null && value is T) ? (T) value : default;

        public static bool Has<T>(this Enum source, params T[] values) {
            var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);

            foreach(var i in values) {
                var mask = Convert.ToInt32(i, CultureInfo.InvariantCulture);

                if((value & mask) == 0) {
                    return false;
                }
            }

            return true;
        }

        public static bool Has<T>(this Enum source, T values) {
            var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
            var mask = Convert.ToInt32(values, CultureInfo.InvariantCulture);

            return (value & mask) != 0;
        }

        public static T Add<T>(this Enum source, T v) {
            var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
            var mask = Convert.ToInt32(v, CultureInfo.InvariantCulture);

            return Enum.ToObject(typeof(T), value | mask).As<T>();
        }

        public static T Remove<T>(this Enum source, T v) {
            var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
            var mask = Convert.ToInt32(v, CultureInfo.InvariantCulture);

            return Enum.ToObject(typeof(T), value & ~mask).As<T>();
        }

        public static T AsEnum<T>(this string value) {
            try {
                return Enum.Parse(typeof(T), value, true).As<T>();
            } catch {
                return default(T);
            }
        }
        #endregion


        #region Unsorted
        // "h1ddengames".Capitalize --> "H1ddengames"
        public static string Capitalize(this string word) => word[0].ToString().ToUpper() + word.Substring(1);

        public static string ReverseString(this string str) {
            if(str.IsNullOrEmpty()) return str;

            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new string(array);
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

        #region Converters
        // Validated. Usage: int i = "123".ChangeType<int>(); --> "123" (string) becomes 123 (int)
        public static T ChangeType<T>(this object obj) where T : IConvertible => (T) Convert.ChangeType(obj, typeof(T));

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

        public static string[] EnumNamesToArray<T>() => Enum.GetNames(typeof(T)).ToArray();

        public static int[] EnumValuesToArray<T>() {
            T[] enumArray = (T[]) Enum.GetValues(typeof(T));
            int[] intArray = new int[enumArray.Length];

            for(int i = 0; i < enumArray.Length; i++) {
                intArray[i] = enumArray[i].ChangeType<int>();
            }

            return intArray;
        }

        public static List<T> EnumNamesToList<T>() => Enum.GetNames(typeof(T)).Cast<T>().ToList();

        public static List<T> EnumValuesToList<T>() => Enum.GetValues(typeof(T)).Cast<T>().ToList();
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

        public static T2 ValueOf<T1, T2>(this Dictionary<T1, T2> source, T1 key) {
            return source[key];
        }

        public static T1 KeyOf<T1, T2>(this Dictionary<T1, T2> source, T2 value) {
            return source.FirstOrDefault(x => x.Value.Equals(value)).Key;
        }
    }
}