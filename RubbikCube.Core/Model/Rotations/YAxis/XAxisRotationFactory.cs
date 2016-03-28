namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisRotationFactory : RotationFactory<YAxisRotation>
    {
        protected override YAxisRotation CreateFaceCounterClockwiseRotation(double angle, uint times)
        {
            return new FaceLeftRotation(angle, times);
        }

        protected override YAxisRotation CreateFaceClockwiseRotation(double angle, uint times)
        {
            return new FaceRightRotation(angle, times);
        }

        protected override YAxisRotation CreateThirdLayerCounterClockwiseRotation(double angle, uint times)
        {
            return new BottomLayerLeftRotation(angle, times);
        }

        protected override YAxisRotation CreateThirdLayerClockwiseRotation(double angle, uint times)
        {
            return new BottomLayerRightRotation(angle, times);
        }

        protected override YAxisRotation CreateFirstLayerCounterClockwiseRotation(double angle, uint times)
        {
            return new TopLayerLeftRotation(angle, times);
        }

        protected override YAxisRotation CreateFirstLayerClockwiseRotation(double angle, uint times)
        {
            return new TopLayerRightRotation(angle, times);
        }
    }
}
