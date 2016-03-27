using System;

namespace RubiksCube.Core.Model.Rotations
{
    public interface IRotationFactory
    {
        FaceRotation CreateRotation(string direction, uint times);

        FaceRotation CreateRotation(string direction, string way, uint times);
    }

    public class RotationFactory : IRotationFactory
    {
        private const double Angle = Math.PI / 2;

        public FaceRotation CreateRotation(string direction, uint times)
        {
            switch (direction)
            {
                case FaceRotation.LeftWhole:
                    return new LeftWholeFaceRotation(Angle, times);
                case FaceRotation.RightWhole:
                    return new RightWholeFaceRotation(Angle, times);
                case FaceRotation.UpWhole:
                    return new UpWholeFaceRotation(Angle, times);
                case FaceRotation.DownWhole:
                    return new DownWholeFaceRotation(Angle, times);
            }

            return null;
        }

        public FaceRotation CreateRotation(string direction, string way, uint times)
        {
            switch(direction)
            {
                case FaceRotation.Right:
                    return new RightFaceRotation(way, Angle, times);
                case FaceRotation.Left:
                    return new LeftFaceRotation(way, Angle, times);
                case FaceRotation.Up:
                    return new TopFaceRotation(way, Angle, times);
                case FaceRotation.Down:
                    return new BottomFaceRotation(way, Angle, times);
                case FaceRotation.Forward:
                    return new ForwardFaceRotation(way, Angle, times);
            }

            return null;
        }
    }
}