﻿using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal abstract class XAxisRotation : Rotation
    {
        protected XAxisRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> MovingFaces => new[] { FaceType.Front, FaceType.Up, FaceType.Back, FaceType.Down, FaceType.Left, FaceType.Right };

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            if (face.Type == FaceType.Left || face.Type == FaceType.Right)
            {
                return face.Facies;
            }

            return face.GetColumn(LayerType);
        }

        public override double[,] CreateMatrix(double angle)
        {
            return RotationMatrixFactory.CreateXAxisRotation(angle);
        }

        protected virtual void FlipPosition(Facie facie, FaceType faceType)
        {
            if (facie.FaciePosition == FaciePositionType.LeftUp)
            {
                facie.FaciePosition = FaciePositionType.LeftDown;
            }
            else if (facie.FaciePosition == FaciePositionType.LeftDown)
            {
                facie.FaciePosition = FaciePositionType.LeftUp;
            }
            else if (facie.FaciePosition == FaciePositionType.MiddleUp)
            {
                facie.FaciePosition = FaciePositionType.MiddleDown;
            }
            else if (facie.FaciePosition == FaciePositionType.MiddleDown)
            {
                facie.FaciePosition = FaciePositionType.MiddleUp;
            }
            else if (facie.FaciePosition == FaciePositionType.RightUp)
            {
                facie.FaciePosition = FaciePositionType.RightDown;
            }
            else if (facie.FaciePosition == FaciePositionType.RightDown)
            {
                facie.FaciePosition = FaciePositionType.RightUp;
            }
        }
    }
}
