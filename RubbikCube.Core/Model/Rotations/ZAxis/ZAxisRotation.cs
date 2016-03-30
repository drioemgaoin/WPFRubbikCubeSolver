using System;
using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public abstract class ZAxisRotation : Rotation
    {
        protected ZAxisRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> MovingFaces => new[] { FaceType.Left, FaceType.Up, FaceType.Right, FaceType.Down };

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetColumn(LayerType);
        }

        public override double[,] CreateRotationMatrix(double angle)
        {
            var matrix = new double[4, 4];
            matrix[0, 0] = Math.Cos(angle);
            matrix[0, 1] = Math.Sin(angle);
            matrix[0, 2] = 0;
            matrix[0, 3] = 0;
            matrix[1, 0] = -Math.Sin(angle);
            matrix[1, 1] = Math.Cos(angle);
            matrix[1, 2] = 0;
            matrix[1, 3] = 0;
            matrix[2, 0] = 0;
            matrix[2, 1] = 0;
            matrix[2, 2] = 1;
            matrix[2, 3] = 0;
            matrix[3, 0] = 0;
            matrix[3, 1] = 0;
            matrix[3, 2] = 0;
            matrix[3, 3] = 1;
                
            return matrix;
        }

        protected static void FlipPosition(Facie facie)
        {
            if (facie.FaciePosition == FaciePositionType.LeftUp)
            {
                facie.FaciePosition = FaciePositionType.RightDown;
            }
            else if (facie.FaciePosition == FaciePositionType.RightDown)
            {
                facie.FaciePosition = FaciePositionType.LeftUp;
            }
            else if (facie.FaciePosition == FaciePositionType.LeftMiddle)
            {
                facie.FaciePosition = FaciePositionType.RightMiddle;
            }
            else if (facie.FaciePosition == FaciePositionType.RightMiddle)
            {
                facie.FaciePosition = FaciePositionType.LeftMiddle;
            }
            else if (facie.FaciePosition == FaciePositionType.LeftDown)
            {
                facie.FaciePosition = FaciePositionType.RightUp;
            }
            else if (facie.FaciePosition == FaciePositionType.RightUp)
            {
                facie.FaciePosition = FaciePositionType.LeftDown;
            }
        }
    }
}
