namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisRotationFactory : RotationFactory<ZAxisRotation>
    {
        protected override ZAxisRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            return new ZAxisClockwise(faceType, layerType, angle, times);
        }

        protected override ZAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            return new ZAxisCounterClockwise(faceType, layerType, -angle, times);
        }
    }
}
