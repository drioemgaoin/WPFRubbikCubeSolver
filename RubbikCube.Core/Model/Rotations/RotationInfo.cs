using System;

namespace RubiksCube.Core.Model.Rotations
{
    public class RotationInfo
    {
        public RotationInfo(LayerType layer, AxisType axis, bool clockwise) : this(FaceType.None, layer, axis, clockwise, 1)
        {
        }

        public RotationInfo(FaceType faceType, LayerType layer, AxisType axis, bool clockwise) : this(faceType, layer, axis, clockwise, 1)
        {
        }

        public RotationInfo(FaceType faceType, LayerType layer, AxisType axis, bool clockwise, uint times)
        {
            FaceType = faceType;
            Layer = layer;
            Axis = axis;
            Clockwise = clockwise;
            Times = times;
        }

        public FaceType FaceType { get; }

        public LayerType Layer { get; }

        public AxisType Axis { get; }

        public bool Clockwise { get; }

        public uint Times { get; }

        public override string ToString()
        {
            return String.Format("Layer: {0}, Axis: {1}, Clockwise: {2}, Times: {3}", Layer, Axis, Clockwise, Times);
        }
    }
}