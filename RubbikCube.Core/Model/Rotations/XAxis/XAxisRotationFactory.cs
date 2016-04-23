using System;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class XAxisRotationFactory : RotationFactory<XAxisRotation>
    {
        protected override XAxisRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Left)
            {
                return new LeftFaceClockwise(layerType, -angle, times);
            }

            if (faceType == FaceType.Right)
            {
                return new RightFaceClockwise(layerType, angle, times);
            }

            throw new InvalidOperationException();
        }

        protected override XAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Left)
            {
                return new LeftFaceCounterClockwise(layerType, angle, times); 
            }

            if (faceType == FaceType.Right)
            {
                return new RightFaceCounterClockwise(layerType, -angle, times);
            }

            throw new InvalidOperationException();
        }
    }
}
