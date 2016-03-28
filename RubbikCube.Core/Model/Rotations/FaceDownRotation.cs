namespace RubiksCube.Core.Model.Rotations
{
    public class FaceDownRotation : YRotation
    {
        public FaceDownRotation(double angle, uint times) : base(true, angle, times)
        {
        }

        protected override LayerType MovingLayer => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

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
