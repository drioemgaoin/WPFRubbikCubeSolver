using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class YAxisCounterClockwise : YAxisRotation
    {
        public YAxisCounterClockwise(FaceType faceType, LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {   
            AxisMovingFaces = new[] { faceType };
        }

        protected override IEnumerable<FaceType> AxisMovingFaces { get; }

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
                    FlipPosition(facie, FaceType.Back);
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Left:
                    FlipPosition(facie, FaceType.Left);
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }

        protected override void FlipPosition(Facie facie, FaceType faceType)
        {
            if (faceType == FaceType.Up)
            {
                if (facie.Position == FaciePositionType.LeftUp)
                {
                    facie.Position = FaciePositionType.LeftDown;
                }
                else if (facie.Position == FaciePositionType.LeftMiddle)
                {
                    facie.Position = FaciePositionType.MiddleDown;
                }
                else if (facie.Position == FaciePositionType.LeftDown)
                {
                    facie.Position = FaciePositionType.RightDown;
                }
                else if (facie.Position == FaciePositionType.MiddleDown)
                {
                    facie.Position = FaciePositionType.RightMiddle;
                }
                else if (facie.Position == FaciePositionType.RightDown)
                {
                    facie.Position = FaciePositionType.RightUp;
                }
                else if (facie.Position == FaciePositionType.RightMiddle)
                {
                    facie.Position = FaciePositionType.MiddleUp;
                }
                else if (facie.Position == FaciePositionType.RightUp)
                {
                    facie.Position = FaciePositionType.LeftUp;
                }
                else if (facie.Position == FaciePositionType.MiddleUp)
                {
                    facie.Position = FaciePositionType.LeftMiddle;
                }
            }
            else if (faceType == FaceType.Down)
            {
                if (facie.Position == FaciePositionType.LeftUp)
                {
                    facie.Position = FaciePositionType.RightUp;
                }
                else if (facie.Position == FaciePositionType.MiddleUp)
                {
                    facie.Position = FaciePositionType.RightMiddle;
                }
                else if (facie.Position == FaciePositionType.RightUp)
                {
                    facie.Position = FaciePositionType.RightDown;
                }
                else if (facie.Position == FaciePositionType.RightMiddle)
                {
                    facie.Position = FaciePositionType.MiddleDown;
                }
                else if (facie.Position == FaciePositionType.RightDown)
                {
                    facie.Position = FaciePositionType.LeftDown;
                }
                else if (facie.Position == FaciePositionType.MiddleDown)
                {
                    facie.Position = FaciePositionType.LeftMiddle;
                }
                else if (facie.Position == FaciePositionType.LeftDown)
                {
                    facie.Position = FaciePositionType.LeftUp;
                }
                else if (facie.Position == FaciePositionType.LeftMiddle)
                {
                    facie.Position = FaciePositionType.MiddleUp;
                }
            }
            else
            {
                base.FlipPosition(facie, faceType);
            }
        }
    }
}
