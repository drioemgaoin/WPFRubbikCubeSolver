namespace RubiksCube.Core.Model.Rotations
{
    public class FaceLeftRotation : XRotation
    {
        public FaceLeftRotation(double angle, uint times) : base(false, angle, times)
        {
        }

        protected override LayerType MovingLayer => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            var sourceFace = cube[faceType];
            sourceFace.Remove(facie);

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
