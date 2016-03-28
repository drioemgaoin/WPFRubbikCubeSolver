namespace RubiksCube.Core.Model.Rotations.XAxis
{
    public class FaceDownRotation : XAxisRotation
    {
        public FaceDownRotation(double angle, uint times) : base(angle, times)
        {
        }

        protected override LayerType LayerType => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    FlipPosition(facie);
                    cube[FaceType.Bottom].Add(facie);
                    break;
                case FaceType.Top:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Top].Add(facie);
                    break;
                case FaceType.Bottom:
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }        
    }
}
