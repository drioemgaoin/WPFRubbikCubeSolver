using System;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public static class RotationAttributeHelper
    {
        public static RotationAttribute GetAttribute(Enum value)
        {
            var field = typeof(FaciePositionType).GetField(Enum.GetName(typeof(FaciePositionType), value));
            return (RotationAttribute)Attribute.GetCustomAttribute(field, typeof(RotationAttribute));
        }
    }
}