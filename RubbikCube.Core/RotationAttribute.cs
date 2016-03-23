using System;
using RubiksCube.Core.Model;

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

        public RotationType Row { get; set; }

        public RotationType Column { get; set; }
    }
}
