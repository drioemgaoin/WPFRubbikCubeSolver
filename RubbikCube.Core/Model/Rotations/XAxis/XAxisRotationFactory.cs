namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class XAxisRotationFactory : RotationFactory<XAxisRotation>
    {
        protected override XAxisRotation CreateClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new XAxisClockwise(layerType, angle, times);
        }

        protected override XAxisRotation CreateCounterClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new XAxisCounterClockwise(layerType, angle, times);
        }
    }
}
