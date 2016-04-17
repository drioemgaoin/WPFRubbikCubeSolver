using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal class ZAxisClockwise : ZAxisRotation
    {
        public ZAxisClockwise(FaceType faceType, LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
            AxisMovingFaces = new[] { faceType };
        }

        protected override IEnumerable<FaceType> AxisMovingFaces { get; }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Left:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Up:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Right:                    
                    FlipPosition(facie, faceType);
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Down:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Right].Add(facie);
                    break;
            }
        }

        protected override void FlipPosition(Facie facie, FaceType faceType)
        {
            if (faceType == FaceType.Front)
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
            else if (faceType == FaceType.Back)
            {
                if (facie.FaciePosition == FaciePositionType.LeftUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftDown;
                }
                else if (facie.FaciePosition == FaciePositionType.MiddleUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftMiddle;
                }
                else if (facie.FaciePosition == FaciePositionType.RightUp)
                {
                    facie.FaciePosition = FaciePositionType.LeftUp;
                }
                else if (facie.FaciePosition == FaciePositionType.RightMiddle)
                {
                    facie.FaciePosition = FaciePositionType.MiddleUp;
                }
                else if (facie.FaciePosition == FaciePositionType.RightDown)
                {
                    facie.FaciePosition = FaciePositionType.RightUp;
                }
                else if (facie.FaciePosition == FaciePositionType.MiddleDown)
                {
                    facie.FaciePosition = FaciePositionType.RightMiddle;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftDown)
                {
                    facie.FaciePosition = FaciePositionType.RightDown;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftMiddle)
                {
                    facie.FaciePosition = FaciePositionType.MiddleDown;
                }
            }
            else if (LayerType == LayerType.First)
            {
                if (faceType == FaceType.Up)
                {
                    if (facie.FaciePosition == FaciePositionType.LeftDown)
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
                }
                else if (faceType == FaceType.Down)
                {
                    if (facie.FaciePosition == FaciePositionType.MiddleDown)
                    {
                        facie.FaciePosition = FaciePositionType.LeftMiddle;
                    }
                    else if (facie.FaciePosition == FaciePositionType.RightDown)
                    {
                        facie.FaciePosition = FaciePositionType.LeftUp;
                    }
                }
                else if (faceType == FaceType.Left)
                {
                    if (facie.FaciePosition == FaciePositionType.RightMiddle)
                    {
                        facie.FaciePosition = FaciePositionType.MiddleDown;
                    }
                    else if (facie.FaciePosition == FaciePositionType.RightUp)
                    {
                        facie.FaciePosition = FaciePositionType.LeftDown;
                    }
                }
                else if (faceType == FaceType.Right)
                {
                    if (facie.FaciePosition == FaciePositionType.LeftDown)
                    {
                        facie.FaciePosition = FaciePositionType.RightDown;
                    }
                    else if (facie.FaciePosition == FaciePositionType.LeftMiddle)
                    {
                        facie.FaciePosition = FaciePositionType.MiddleDown;
                    }
                    else if (facie.FaciePosition == FaciePositionType.LeftUp)
                    {
                        facie.FaciePosition = FaciePositionType.LeftDown;
                    }
                }
            } 
            else
            {
                if (faceType == FaceType.Up)
                {
                    if (facie.FaciePosition == FaciePositionType.LeftUp)
                    {
                        facie.FaciePosition = FaciePositionType.LeftDown;
                    }
                    else if (facie.FaciePosition == FaciePositionType.MiddleUp)
                    {
                        facie.FaciePosition = FaciePositionType.LeftMiddle;
                    }
                    else if (facie.FaciePosition == FaciePositionType.RightUp)
                    {
                        facie.FaciePosition = FaciePositionType.LeftUp;
                    }
                }
                else if (faceType == FaceType.Down)
                {
                    if (facie.FaciePosition == FaciePositionType.MiddleUp)
                    {
                        facie.FaciePosition = FaciePositionType.RightMiddle;
                    }
                    else if (facie.FaciePosition == FaciePositionType.LeftUp)
                    {
                        facie.FaciePosition = FaciePositionType.RightDown;
                    }
                }
                else if (faceType == FaceType.Left)
                {
                    if (facie.FaciePosition == FaciePositionType.LeftMiddle)
                    {
                        facie.FaciePosition = FaciePositionType.MiddleUp;
                    }
                    else if (facie.FaciePosition == FaciePositionType.LeftDown)
                    {
                        facie.FaciePosition = FaciePositionType.RightUp;
                    }
                }
                else if (faceType == FaceType.Right)
                {
                    if (facie.FaciePosition == FaciePositionType.RightUp)
                    {
                        facie.FaciePosition = FaciePositionType.LeftUp;
                    }
                    else if (facie.FaciePosition == FaciePositionType.RightMiddle)
                    {
                        facie.FaciePosition = FaciePositionType.MiddleUp;
                    }
                    else if (facie.FaciePosition == FaciePositionType.RightDown)
                    {
                        facie.FaciePosition = FaciePositionType.RightUp;
                    }
                }
            }
        }
    }
}
