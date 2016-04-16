namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisRotationFactory : RotationFactory<YAxisRotation>
    {
        protected override YAxisRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            return new YAxisClockwise(faceType, layerType, angle, times);
        }

        protected override YAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            return new YAxisCounterClockwise(faceType, layerType, angle, times);
        }
    }
}
