using System;

namespace RubiksCube.Core.Model.Rotations
{
    public class RotationInfo
    {
        public RotationInfo(string layer, char axis, string way) : this(layer, axis, way, 1)
        {
        }

        public RotationInfo(string layer, char axis, string way, uint times)
        {
            Guard.IsNotNullOrWhitespace(layer, "layer");
            Guard.IsNotNullOrWhitespace(way, "way");

            Layer = (LayerType)Enum.Parse(typeof(LayerType), layer);
            Axis = (AxisType)Enum.Parse(typeof(AxisType), axis.ToString()); 
            Clockwise = way == LayerMove.Clockwise;
            Times = times;
        }

        public RotationInfo(LayerType layer, AxisType axis, bool clockwise) : this(layer, axis, clockwise, 1)
        {
        }

        public RotationInfo(LayerType layer, AxisType axis, bool clockwise, uint times)
        {
            Layer = layer;
            Axis = axis;
            Clockwise = clockwise;
            Times = times;
        }

        public LayerType Layer { get; }

        public AxisType Axis { get; }

        public bool Clockwise { get; }

        public uint Times { get; }

        public override string ToString()
        {
            return string.Format("Layer: {0}, Axis: {1}, Clockwise: {2}, Times: {3}", Layer, Axis, Clockwise, Times);
        }
    }
}