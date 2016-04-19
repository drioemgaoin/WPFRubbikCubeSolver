using System;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;

namespace RubiksCube.Core.Model.Rotations
{
    internal interface IRotationFactory
    {
        Rotation CreateRotation(RotationInfo info);
    }

    internal abstract class RotationFactory<TRotation> : IRotationFactory where TRotation : Rotation
    {
        private const double Angle = Math.PI / 2;

        protected abstract TRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times);

        protected abstract TRotation CreateCounterClockwiseRotation(FaceType fceType, LayerType layerType, double angle, uint times);

        public Rotation CreateRotation(RotationInfo info)
        {
            if (info.Clockwise)
            {
                return CreateClockwiseRotation(info.Face, info.Layer, Angle, info.Times);
            }

            return CreateCounterClockwiseRotation(info.Face, info.Layer, Angle, info.Times);
        }        
    }

    internal class RotationFactory
    {
        private readonly XAxisRotationFactory xRotationFactory = new XAxisRotationFactory();
        private readonly YAxisRotationFactory yAxisRotationFactory = new YAxisRotationFactory();
        private readonly ZAxisRotationFactory zAxisRotationFactory = new ZAxisRotationFactory();

        public Rotation CreateRotation(RotationInfo info)
        {
            switch (info.Face)
            {
                case FaceType.Left:
                case FaceType.Right:
                    return xRotationFactory.CreateRotation(info);
                case FaceType.Up:
                case FaceType.Down:
                    return yAxisRotationFactory.CreateRotation(info);
                case FaceType.Back:
                case FaceType.Front:
                    return zAxisRotationFactory.CreateRotation(info);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}