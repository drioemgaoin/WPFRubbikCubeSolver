namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class XAxisRotationFactory : RotationFactory<XAxisRotation>
    {
        protected override XAxisRotation CreateClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            return new XAxisClockwise(faceType, layerType, angle, times);
        }

        protected override XAxisRotation CreateCounterClockwiseRotation(FaceType faceType, LayerType layerType, double angle, uint times)
        {
            return new XAxisCounterClockwise(faceType, layerType, angle, times);
        }
    }
}
