using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> items) where T : ICloneable
        {
            return items.Select(item => (T)item.Clone()).ToList();
        }
    }
}
