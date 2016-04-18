﻿using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class RightFaceCounterClockwise : XAxisRotation
    {
        public RightFaceCounterClockwise(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisMovingFaces => new[] { FaceType.Right };

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Up:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Down:
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }

        protected override void FlipPosition(Facie facie, FaceType faceType)
        {
            if (faceType == FaceType.Right)
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
            else if (faceType == FaceType.Front)
            {
                if (facie.Position == FaciePositionType.RightUp)
                {
                    facie.Position = FaciePositionType.RightDown;
                }
                else if (facie.Position == FaciePositionType.RightDown)
                {
                    facie.Position = FaciePositionType.RightUp;
                }
            }
            else if (faceType == FaceType.Back)
            {
                if (facie.Position == FaciePositionType.RightDown)
                {
                    facie.Position = FaciePositionType.RightUp;
                }
                else if (facie.Position == FaciePositionType.RightUp)
                {
                    facie.Position = FaciePositionType.RightDown;
                }
            }
        }
    }
}