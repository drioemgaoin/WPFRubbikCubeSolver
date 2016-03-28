namespace RubiksCube.Core.Model.Rotations
{
    public class FaceRightRotation : XRotation
    {
        public FaceRightRotation(double angle, uint times) : base(true, angle, times)
        {
        }

        protected override LayerType MovingLayer => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Right:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Left:
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}
