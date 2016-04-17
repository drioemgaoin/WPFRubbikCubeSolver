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

            return new YAxisClockwise(faceType, layerType, angle, times);
        }

        protected override YAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            if (faceType == FaceType.Up)
            {
                return new UpFaceCounterClockwise(layerType, angle, times);
            }

            return new YAxisCounterClockwise(faceType, layerType, angle, times);
        }
    }
}
