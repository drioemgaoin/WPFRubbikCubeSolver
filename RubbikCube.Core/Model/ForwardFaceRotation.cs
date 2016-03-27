﻿using System.Collections.Generic;

namespace RubiksCube.Core.Model
{
    public class ForwardFaceRotation : FaceRotation
    {
        public ForwardFaceRotation(string way, double angle, uint times) 
            : base(way, angle, times)
        {
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return rotationMatrixFactory.CreateZRotationMatrix(angle);
        }

        protected override IEnumerable<FaceType> GetImpactedFaceTypes()
        {
            return new[] { FaceType.Left, FaceType.Top, FaceType.Right, FaceType.Bottom };
        }

        protected override IEnumerable<Facie> GetImpactedFacies(Face face)
        {
            if(face.Type == FaceType.Left)
            {
                return face.GetColumnFacies(RotationType.First);
            }

            if(face.Type == FaceType.Right)
            {
                return face.GetColumnFacies(RotationType.Third);
            }

            return face.GetRowFacies(RotationType.First);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation)
        {
            var sourceFace = cube.Find(faceType);
            sourceFace.Facies.Remove(facie);

            switch (faceType)
            {
                case FaceType.Left:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.TopFace.Facies.Add(facie);
                    }
                    else
                    {
                        cube.BottomFace.Facies.Add(facie);
                    }
                    break;
                case FaceType.Top:
                    if (isPositiveRotation)
                    {
                        cube.RightFace.Facies.Add(facie);
                    }
                    else
                    {
                        cube.FrontFace.Facies.Add(facie);
                    }
                    break;
                case FaceType.Right:
                    if (isPositiveRotation)
                    {
                        cube.BottomFace.Facies.Add(facie);
                    }
                    else
                    {
                        cube.TopFace.Facies.Add(facie);
                    }
                    break;
                case FaceType.Bottom:
                    if (isPositiveRotation)
                    {
                        cube.FrontFace.Facies.Add(facie);
                    }
                    else
                    {
                        cube.RightFace.Facies.Add(facie);
                    }
                    break;
            }
        }

        // TODO: same method for rignt/left face rotation -> create abstraction
        private static void FlipPosition(Facie facie)
        {
            if(facie.FaciePosition == FaciePositionType.RightBottom)
            {
                facie.FaciePosition = FaciePositionType.LeftBottom;
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