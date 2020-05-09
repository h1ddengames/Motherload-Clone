// Created by h1ddengames

using System;

namespace h1ddengames.Extensions {
    public class Tools {
        #region Helper Methods
        public static T RandomEnumValue<T>() {
            var v = Enum.GetValues(typeof(T));
            return (T) v.GetValue(new Random().Next(v.Length));
        }
        #endregion
    }
}