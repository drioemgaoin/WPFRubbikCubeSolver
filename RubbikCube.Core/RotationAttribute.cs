using System;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class RotationAttribute : Attribute
    {
        public RotationAttribute(LayerType row, LayerType column)
        {
            Row = row;
            Column = column;
        }

        public LayerType Row { get; private set; }

        public LayerType Column { get; private set; }
    }
}
