using System;

namespace RubiksCube.Core.Model.Rotations
{
    public interface IRotationFactory
    {
        Rotation CreateFaceRotation(string direction);

        Rotation CreateFaceRotation(string direction, uint times);

        Rotation CreateLayerRotation(RotationInfo info);
    }

    public class RotationFactory : IRotationFactory
    {
        private const double Angle = Math.PI / 2;

        public Rotation CreateFaceRotation(string directions)
        {
            return CreateFaceRotation(directions, 1);
        }

        public Rotation CreateFaceRotation(string direction, uint times)
        {
            switch (direction)
            {
                case FaceMove.Left:
                    return new FaceLeftRotation(Angle, times);
                case FaceMove.Right:
                    return new FaceRightRotation(Angle, times);
                case FaceMove.Up:
                    return new FaceUpRotation(Angle, times);
                case FaceMove.Down:
                    return new FaceDownRotation(Angle, times);
            }

            throw new InvalidOperationException(string.Format("'{0}' is not a valid face rotation direction.", direction));
        }

        public Rotation CreateLayerRotation(RotationInfo info)
        {
            if (info.Axis == AxisType.X)
            {
                if (info.Layer == LayerType.First)
                {
                    return new TopLayerRotation(info.Clockwise, Angle, info.Times);
                }

                if (info.Layer == LayerType.Third)
                {
                    return new BottomLayerRotation(info.Clockwise, Angle, info.Times);
                }
            }

            if (info.Axis == AxisType.Y)
            {
                if (info.Layer == LayerType.First)
                {
                    return new LeftLayerRotation(info.Clockwise, Angle, info.Times);
                }

                if (info.Layer == LayerType.Third)
                {
                    return new RightLayerRotation(info.Clockwise, Angle, info.Times);
                }
            }

            if (info.Axis == AxisType.Z)
            {
                if (info.Layer == LayerType.Third)
                {
                    return new BottomLayerRotation(info.Clockwise, Angle, info.Times);
                }
            }            

            throw new InvalidOperationException(string.Format("Layer rotation '{0}' is not implemented.", info));
        }
    }
}