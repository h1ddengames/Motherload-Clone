// Created by h1ddengames

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace h1ddengames.Extensions {
    public class Tools {
        #region Private Fields
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        #endregion

        #region Helper Methods
        public static T RandomEnumValue<T>() {
            var v = Enum.GetValues(typeof(T));
            return (T) v.GetValue(NextRandomInt(v.Length));
        }

        public static T GetRandomArrayValue<T>(T[] array) {
            return array[NextRandomInt(0, array.Length)];
        }

        public static T GetRandomListValue<T>(List<T> list) {
            return list[NextRandomInt(0, list.Count)];
        }

        public static T1 RandomDictionaryKey<T1, T2>(Dictionary<T1, T2> dictionary) {
            return dictionary.ElementAt(NextRandomInt(0, dictionary.Count)).Key;
        }

        public static T2 RandomDictionaryValue<T1, T2>(Dictionary<T1, T2> dictionary) {
            return dictionary.ElementAt(NextRandomInt(0, dictionary.Count)).Value;
        }

        public static int NextRandomInt() {
            return random.Value.Next();
        }

        public static int NextRandomInt(int max) {
            return random.Value.Next(max);
        }

        public static int NextRandomInt(int min, int max) {
            return random.Value.Next(min, max);
        }

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
    }
}