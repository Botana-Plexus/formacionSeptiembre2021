using System;

namespace util{
    public class EnumUtils{
        public static int getEnumIndexFor<T>(T value)
        {
            return Array.IndexOf(Enum.GetValues(value.GetType()), value);
        }

        public static T getEnumValueAt<T>(int index)
        {
            return (T) Enum.GetValues(typeof(T)).GetValue(index);
        }
    }
}