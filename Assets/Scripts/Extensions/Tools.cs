// Created by h1ddengames

using System;
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
        #endregion
    }
}