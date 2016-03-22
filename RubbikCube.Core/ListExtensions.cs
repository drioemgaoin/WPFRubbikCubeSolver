using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core
{
    public static class ListExtensions
    {
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
