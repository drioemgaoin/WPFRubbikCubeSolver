using System;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class RotationAttribute : Attribute
    {
        public RotationAttribute(RotationType row, RotationType column)
        {
            Row = row;
            Column = column;
        }

        public RotationType Row { get; private set; }

        public RotationType Column { get; private set; }
    }
}
