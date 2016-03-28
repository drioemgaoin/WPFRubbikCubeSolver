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

        protected abstract TRotation CreateClockwiseRotation(LayerType layerType, double angle, uint times);

        protected abstract TRotation CreateCounterClockwiseRotation(LayerType layerType, double angle, uint times);

        public Rotation CreateRotation(RotationInfo info)
        {
            if (info.Clockwise)
            {
                return CreateClockwiseRotation(info.Layer, Angle, info.Times);
            }

            return CreateCounterClockwiseRotation(info.Layer, -Angle, info.Times);
        }        
    }
}