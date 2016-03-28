namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisRotationFactory : RotationFactory<ZAxisRotation>
    {
        protected override ZAxisRotation CreateFaceCounterClockwiseRotation(double angle, uint times)
        {
            return new FaceLeftRotation(angle, times);
        }

        protected override ZAxisRotation CreateFaceClockwiseRotation(double angle, uint times)
        {
            return new FaceRightRotation(angle, times);
        }

        protected override ZAxisRotation CreateThirdLayerCounterClockwiseRotation(double angle, uint times)
        {
            return new BackLayerLeftRotation(angle, times);
        }

        protected override ZAxisRotation CreateThirdLayerClockwiseRotation(double angle, uint times)
        {
            return new BackLayerRightRotation(angle, times);
        }

        protected override ZAxisRotation CreateFirstLayerCounterClockwiseRotation(double angle, uint times)
        {
            return new FrontLayerLeftRotation(angle, times);
        }

        protected override ZAxisRotation CreateFirstLayerClockwiseRotation(double angle, uint times)
        {
            return new FrontLayerRightRotation(angle, times);
        }
    }
}
