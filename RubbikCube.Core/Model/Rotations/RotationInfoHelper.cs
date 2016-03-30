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
            switch (info.Axis)
            {
                case AxisType.X:
                    return new XAxisRotationFactory();
                case AxisType.Y:
                    return new YAxisRotationFactory();
                case AxisType.Z:
                    return new ZAxisRotationFactory();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}