using System;

namespace RubiksCube.Core.Model.Rotations
{
    public interface IRotationFactory
    {
        Rotation CreateRotation(RotationInfo info);
    }

    internal abstract class RotationFactory<TRotation> : IRotationFactory where TRotation : Rotation
    {
        private const double Angle = Math.PI / 2;

        protected abstract TRotation CreateFaceCounterClockwiseRotation(double angle, uint times);

        protected abstract TRotation CreateFaceClockwiseRotation(double angle, uint times);

        protected abstract TRotation CreateThirdLayerCounterClockwiseRotation(double angle, uint times);

        protected abstract TRotation CreateThirdLayerClockwiseRotation(double angle, uint times);

        protected abstract TRotation CreateFirstLayerCounterClockwiseRotation(double angle, uint times);

        protected abstract TRotation CreateFirstLayerClockwiseRotation(double angle, uint times);

        public Rotation CreateRotation(RotationInfo info)
        {
            if (info.Layer == LayerType.First)
            {
                if (info.Clockwise)
                {
                    return CreateFirstLayerClockwiseRotation(Angle, info.Times);
                }

                return CreateFirstLayerCounterClockwiseRotation(-Angle, info.Times);
            }

            if (info.Layer == LayerType.Third)
            {
                if (info.Clockwise)
                {
                    return CreateThirdLayerClockwiseRotation(Angle, info.Times);
                }

                return CreateThirdLayerCounterClockwiseRotation(-Angle, info.Times);
            }

            if (info.Layer == LayerType.All)
            {
                if (info.Clockwise)
                {
                    return CreateFaceClockwiseRotation(Angle, info.Times);
                }

                return CreateFaceCounterClockwiseRotation(-Angle, info.Times);
            }

            throw new NotImplementedException(info + " is not implemented.");
        }        
    }
}