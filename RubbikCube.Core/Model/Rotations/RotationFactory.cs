using System;

namespace RubiksCube.Core.Model.Rotations
{
    public interface IRotationFactory
    {
        Rotation CreateFaceRotation(string direction, uint times);

        Rotation CreateLayerRotation(string direction, string way, uint times);
    }

    public class RotationFactory : IRotationFactory
    {
        private const double Angle = Math.PI / 2;

        public Rotation CreateFaceRotation(string direction, uint times)
        {
            switch (direction)
            {
                case Rotation.LeftWhole:
                    return new FaceLeftRotation(Angle, times);
                case Rotation.RightWhole:
                    return new FaceRightRotation(Angle, times);
                case Rotation.UpWhole:
                    return new FaceUpRotation(Angle, times);
                case Rotation.DownWhole:
                    return new FaceDownRotation(Angle, times);
            }

            return null;
        }

        public Rotation CreateLayerRotation(string direction, string way, uint times)
        {
            switch(direction)
            {
                case Rotation.Right:
                    return new RightLayerRotation(way, Angle, times);
                case Rotation.Left:
                    return new LeftLayerRotation(way, Angle, times);
                case Rotation.Up:
                    return new TopLayerRotation(way, Angle, times);
                case Rotation.Down:
                    return new BottomLayerRotation(way, Angle, times);
                case Rotation.Forward:
                    return new FrontLayerRotation(way, Angle, times);
            }

            return null;
        }
    }
}