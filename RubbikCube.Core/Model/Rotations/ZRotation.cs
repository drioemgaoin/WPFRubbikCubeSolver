using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public abstract class ZRotation : Rotation
    {
        protected ZRotation(bool clockwise, double angle, uint times) : base(clockwise, angle, times)
        {
        }

        protected override IEnumerable<FaceType> MovingFaces => new[] { FaceType.Front, FaceType.Top, FaceType.Back, FaceType.Bottom };

        public override double[,] GetRotationMatrix(double angle)
        {
            return RotationMatrixFactory.CreateZRotationMatrix(angle);
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetZLayer(MovingLayer);
        }

        protected void FlipPosition(Facie facie)
        {
            if (IsClockwise)
            {
                if (facie.FaciePosition == FaciePositionType.RightBottom)
                {
                    facie.FaciePosition = FaciePositionType.LeftBottom;
                }
            }

            if (facie.FaciePosition == FaciePositionType.RightMiddle)
            {
                facie.FaciePosition = FaciePositionType.MiddleBottom;
            }

            if (facie.FaciePosition == FaciePositionType.RightTop)
            {
                facie.FaciePosition = FaciePositionType.RightBottom;
            }

            if (facie.FaciePosition == FaciePositionType.LeftBottom)
            {
                facie.FaciePosition = FaciePositionType.LeftTop;
            }

            if (facie.FaciePosition == FaciePositionType.MiddleBottom)
            {
                facie.FaciePosition = FaciePositionType.LeftMiddle;
            }

            if (facie.FaciePosition == FaciePositionType.RightBottom)
            {
                facie.FaciePosition = FaciePositionType.LeftBottom;
            }
        }
    }
}
