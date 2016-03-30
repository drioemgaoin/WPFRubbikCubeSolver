namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class XAxisClockwise : XAxisRotation
    {
        public XAxisClockwise(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Up:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Down:
                    FlipPosition(facie);
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}