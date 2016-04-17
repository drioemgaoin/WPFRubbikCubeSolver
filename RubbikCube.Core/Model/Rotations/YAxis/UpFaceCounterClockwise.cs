using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal class UpFaceCounterClockwise : YAxisRotation
    {
        public UpFaceCounterClockwise(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisMovingFaces => new[] { FaceType.Up };

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Left:
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }

        protected override void FlipPosition(Facie facie, FaceType faceType)
        {
            if (faceType == FaceType.Up)
            {
                if (facie.FaciePosition == FaciePositionType.LeftUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftDown;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftMiddle)
                {
                    facie.FaciePosition = FaciePositionType.MiddleDown;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftDown)
                {
                    facie.FaciePosition = FaciePositionType.RightDown;
                }
                else if (facie.FaciePosition == FaciePositionType.MiddleDown)
                {
                    facie.FaciePosition = FaciePositionType.RightMiddle;
                }
                else if (facie.FaciePosition == FaciePositionType.RightDown)
                {
                    facie.FaciePosition = FaciePositionType.RightUp;
                }
                else if (facie.FaciePosition == FaciePositionType.RightMiddle)
                {
                    facie.FaciePosition = FaciePositionType.MiddleUp;
                }
                else if (facie.FaciePosition == FaciePositionType.RightUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftUp;
                }
                else if (facie.FaciePosition == FaciePositionType.MiddleUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftMiddle;
                }
            }
            else if (faceType == FaceType.Front)
            {
                if (facie.FaciePosition == FaciePositionType.RightUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftUp;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftUp)
                {
                    facie.FaciePosition = FaciePositionType.RightUp;
                }
            }
            else if (faceType == FaceType.Back)
            {
                if (facie.FaciePosition == FaciePositionType.LeftUp)
                {
                    facie.FaciePosition = FaciePositionType.RightUp;
                }
                else if (facie.FaciePosition == FaciePositionType.RightUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftUp;
                }
            }
        }
    }
}
