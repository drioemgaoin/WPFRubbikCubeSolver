using System;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public static class ReflectionHelper
    {
        public static RotationAttribute GetRotationAttribute(Enum value)
        {
            var field = typeof(FaciePositionType).GetField(Enum.GetName(typeof(FaciePositionType), value));
            return (RotationAttribute)Attribute.GetCustomAttribute(field, typeof(RotationAttribute));
        }
    }
}