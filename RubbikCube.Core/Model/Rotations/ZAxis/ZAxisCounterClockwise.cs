namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisCounterClockwise : ZAxisRotation
    {
        public ZAxisCounterClockwise(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Left:
                    FlipPosition(facie);
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Up:
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Down:
                    FlipPosition(facie);
                    cube[FaceType.Right].Add(facie);
                    break;
            }
        }
    }
}
