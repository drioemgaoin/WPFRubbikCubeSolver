namespace RubiksCube.Core.Model.Rotations
{
    public class FrontLayerRotation : ZRotation
    {
        public FrontLayerRotation(bool clockwise, double angle, uint times) : base(clockwise, angle, times)
        {
        }

        protected override LayerType MovingLayer => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            switch (faceType)
            {
                case FaceType.Left:
                    if (IsClockwise)
                    {
                        FlipPosition(facie);
                        cube[FaceType.Top].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Bottom].Add(facie);
                    }
                    break;
                case FaceType.Top:
                    if (IsClockwise)
                    {
                        cube[FaceType.Right].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Front].Add(facie);
                    }
                    break;
                case FaceType.Right:
                    if (IsClockwise)
                    {
                        cube[FaceType.Bottom].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Top].Add(facie);
                    }
                    break;
                case FaceType.Bottom:
                    if (IsClockwise)
                    {
                        cube[FaceType.Front].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Right].Add(facie);
                    }
                    break;
            }
        }
    }
}
