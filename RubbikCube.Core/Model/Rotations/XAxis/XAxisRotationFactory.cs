namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class XAxisRotationFactory : RotationFactory<XAxisRotation>
    {
        protected override XAxisRotation CreateFaceCounterClockwiseRotation(double angle, uint times)
        {
            return new FaceDownRotation(angle, times);
        }

        protected override XAxisRotation CreateFaceClockwiseRotation(double angle, uint times)
        {
            return new FaceUpRotation(angle, times);
        }

        protected override XAxisRotation CreateThirdLayerCounterClockwiseRotation(double angle, uint times)
        {
            return new RightLayerDownRotation(angle, times);
        }

        protected override XAxisRotation CreateThirdLayerClockwiseRotation(double angle, uint times)
        {
            return new RightLayerUpRotation(angle, times);
        }

        protected override XAxisRotation CreateFirstLayerCounterClockwiseRotation(double angle, uint times)
        {
            return new LeftLayerDownRotation(angle, times);
        }

        protected override XAxisRotation CreateFirstLayerClockwiseRotation(double angle, uint times)
        {
            return new LeftLayerUpRotation(angle, times);
        }
    }
}
