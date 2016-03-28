namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisRightRotation : ZAxisRotation
    {
        public ZAxisRightRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Left:
                    FlipPosition(facie);
                    cube[FaceType.Top].Add(facie);
                    break;
                case FaceType.Top:
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Bottom].Add(facie);
                    break;
                case FaceType.Bottom:
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}
