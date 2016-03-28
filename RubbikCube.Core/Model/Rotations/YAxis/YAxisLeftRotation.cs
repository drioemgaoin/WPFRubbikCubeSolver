namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisLeftRotation : YAxisRotation
    {
        public YAxisLeftRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Left:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }
    }
}
