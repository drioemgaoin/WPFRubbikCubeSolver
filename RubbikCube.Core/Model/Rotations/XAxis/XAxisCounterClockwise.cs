namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class XAxisCounterClockwise : XAxisRotation
    {
        public XAxisCounterClockwise(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    FlipPosition(facie);
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Up:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Down:
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }
    }
}
