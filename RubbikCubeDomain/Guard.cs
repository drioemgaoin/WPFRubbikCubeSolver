using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksCube
{
    public class Guard
    {
        public static void IsNotNullOrWhitespace(string instance, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(instance))
            {
                throw new ArgumentException(string.Format("{0} does not allow null or whitespace.", parameterName));
            }
        }

        public static void Contains<T>(IEnumerable<T> collection, T item, string message)
        {
            if (!collection.Contains(item))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
