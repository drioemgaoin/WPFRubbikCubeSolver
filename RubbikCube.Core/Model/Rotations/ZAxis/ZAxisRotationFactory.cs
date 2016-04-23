using System;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisRotationFactory : RotationFactory<ZAxisRotation>
    {
        protected override ZAxisRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Front)
            {
                return new ZAxisClockwise(faceType, layerType, -angle, times);
            }

            if (faceType == FaceType.Back)
            {
                return new ZAxisCounterClockwise(faceType, layerType, angle, times);
            }

            throw new InvalidOperationException();
        }

        protected override ZAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Front)
            {
                return new ZAxisCounterClockwise(faceType, layerType, angle, times);
            }

            if (faceType == FaceType.Back)
            {
                return new ZAxisClockwise(faceType, layerType, -angle, times);
            }

            throw new InvalidOperationException();
        }
    }
}
