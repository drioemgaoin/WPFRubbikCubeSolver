namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisRotationFactory : RotationFactory<ZAxisRotation>
    {
        protected override ZAxisRotation CreateClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new ZAxisRightRotation(layerType, angle, times);
        }

        protected override ZAxisRotation CreateCounterClockwiseRotation(LayerType layerType, double angle, uint times)
        {
            return new ZAxisLeftRotation(layerType, angle, times);
        }
    }
}
