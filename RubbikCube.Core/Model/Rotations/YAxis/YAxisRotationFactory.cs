using System;

namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisRotationFactory : RotationFactory<YAxisRotation>
    {
        protected override YAxisRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Up)
            {
                return new UpFaceClockwise(layerType, -angle, times);
            }

            if (faceType == FaceType.Down)
            {
                return new DownFaceClockwise(layerType, angle, times);
            }

            throw new InvalidOperationException();
        }

        protected override YAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Up)
            {
                return new UpFaceCounterClockwise(layerType, Math.Abs(angle), times);
            }

            if (faceType == FaceType.Down)
            {
                return new DownFaceCounterClockwise(layerType, -Math.Abs(angle), times);
            }

            throw new InvalidOperationException();
        }
    }
}
