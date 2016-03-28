﻿using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public abstract class YRotation : Rotation
    {
        protected YRotation(bool clockwise, double angle, uint times) : base(clockwise, angle, times)
        {
        }

        protected override IEnumerable<FaceType> MovingFaces => new[] { FaceType.Front, FaceType.Top, FaceType.Back, FaceType.Bottom };

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetYLayer(MovingLayer);
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return RotationMatrixFactory.CreateYRotationMatrix(angle);
        }

        protected static void FlipPosition(Facie facie)
        {
            if (facie.FaciePosition == FaciePositionType.LeftTop)
            {
                facie.FaciePosition = FaciePositionType.LeftBottom;
            }
            else if (facie.FaciePosition == FaciePositionType.LeftBottom)
            {
                facie.FaciePosition = FaciePositionType.LeftTop;
            }
            else if (facie.FaciePosition == FaciePositionType.MiddleTop)
            {
                facie.FaciePosition = FaciePositionType.MiddleBottom;
            }
            else if (facie.FaciePosition == FaciePositionType.MiddleBottom)
            {
                facie.FaciePosition = FaciePositionType.MiddleTop;
            }
            else if (facie.FaciePosition == FaciePositionType.RightTop)
            {
                facie.FaciePosition = FaciePositionType.RightBottom;
            }
            else if (facie.FaciePosition == FaciePositionType.RightBottom)
            {
                facie.FaciePosition = FaciePositionType.RightTop;
            }
        }
    }
}
