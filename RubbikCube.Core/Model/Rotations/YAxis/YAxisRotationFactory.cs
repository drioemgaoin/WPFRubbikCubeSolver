namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisRotationFactory : RotationFactory<YAxisRotation>
    {
        protected override YAxisRotation CreateClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new YAxisRightRotation(layerType, angle, times);
        }

        protected override YAxisRotation CreateCounterClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new YAxisLeftRotation(layerType, angle, times);
        }
    }
}
