namespace RubiksCube.Core.Model.Rotations
{
    public class FaceUpRotation : YRotation
    {
        public FaceUpRotation(double angle, uint times) : base(false, angle, times)
        {
        }

        protected override LayerType MovingLayer => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

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
