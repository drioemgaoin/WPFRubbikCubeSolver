namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisRotationFactory : RotationFactory<YAxisRotation>
    {
        protected override YAxisRotation CreateClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new YAxisClockwise(layerType, angle, times);
        }

        protected override YAxisRotation CreateCounterClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new YAxisCounterClockwise(layerType, angle, times);
        }
    }
}
