using System;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class RotationAttribute : Attribute
    {
        public RotationAttribute(CubeLayerType row, CubeLayerType column)
        {
            Row = row;
            Column = column;
        }

        public CubeLayerType Row { get; private set; }

        public CubeLayerType Column { get; private set; }
    }
}
