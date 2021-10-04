using System;
using System.Linq;

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
        
        public static T[] toEnumArray<T>(params int[] values) where T: struct, IConvertible
        {
            T[] result = null;
            if (typeof(T).IsEnum)
            {
                result = values.Select(EnumUtils.getEnumValueAt<T>).ToArray();
            }
            return result;
        }
    }
}