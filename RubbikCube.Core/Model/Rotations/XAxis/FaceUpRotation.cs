namespace RubiksCube.Core.Model.Rotations.XAxis
{
    public class FaceUpRotation : XAxisRotation
    {
        public FaceUpRotation(double angle, uint times) : base(angle, times)
        {
        }

        protected override LayerType LayerType => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Top].Add(facie);
                    break;
                case FaceType.Top:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    cube[FaceType.Bottom].Add(facie);
                    break;
                case FaceType.Bottom:
                    FlipPosition(facie);
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}
