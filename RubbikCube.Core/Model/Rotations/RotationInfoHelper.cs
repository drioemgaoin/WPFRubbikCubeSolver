using System;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;

namespace RubiksCube.Core.Model.Rotations
{
    public static class RotationInfoHelper
    {
        public static Rotation CreateRotation(this RotationInfo info)
        {
            var factory = CreateConcreteFactory(info);

            return factory.CreateRotation(info);
        }

        private static IRotationFactory CreateConcreteFactory(RotationInfo info)
        {
            switch (info.Face)
            {
                case FaceType.Left:
                case FaceType.Right:
                    return new XAxisRotationFactory();
                case FaceType.Up:
                case FaceType.Down:
                    return new YAxisRotationFactory();
                case FaceType.Back:
                case FaceType.Front:
                    return new ZAxisRotationFactory();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}