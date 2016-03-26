using System.Collections.Generic;

namespace RubiksCube.Core.Model
{
    public class BottomFaceRotation : FaceRotation
    {
        public BottomFaceRotation(string way, double angle, uint times)
            : base(way, angle, times)
        {
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return rotationMatrixFactory.CreateXRotationMatrix(angle);
        }

        protected override IEnumerable<FaceType> GetImpactedFaceTypes()
        {
            return new[] { FaceType.Front, FaceType.Left, FaceType.Back, FaceType.Right };
        }

        protected override IEnumerable<Facie> GetImpactedFacies(Face face)
        {
            return face.GetRowFacies(RotationType.Third);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation)
        {
            var sourceFace = cube.Find(faceType);
            sourceFace.Facies.Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    if (isPositiveRotation)
                    {
                        cube.RightFace.Facies.Add(facie);
                    }
                    else
                    {
                        cube.LeftFace.Facies.Add(facie);
                    }
                    break;
                case FaceType.Right:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.BackFace.Facies.Add(facie);
                    }
                    else
                    {
                        cube.FrontFace.Facies.Add(facie);
                    }
                    break;
                case FaceType.Back:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.LeftFace.Facies.Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube.RightFace.Facies.Add(facie);
                    }
                    break;
                case FaceType.Left:
                    if (isPositiveRotation)
                    {
                        cube.FrontFace.Facies.Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube.BackFace.Facies.Add(facie);
                    }
                    break;
            }
        }

        // TODO: same method for top/bottom face rotation -> create abstraction
        private static void FlipPosition(Facie facie)
        {
            if (facie.FaciePosition == FaciePositionType.LeftTop)
            {
                facie.FaciePosition = FaciePositionType.RightTop;
            }
            else if (facie.FaciePosition == FaciePositionType.RightTop)
            {
                facie.FaciePosition = FaciePositionType.LeftTop;
            }
            else if (facie.FaciePosition == FaciePositionType.LeftMiddle)
            {
                facie.FaciePosition = FaciePositionType.RightMiddle;
            }
            else if (facie.FaciePosition == FaciePositionType.RightMiddle)
            {
                facie.FaciePosition = FaciePositionType.LeftMiddle;
            }
            else if (facie.FaciePosition == FaciePositionType.LeftBottom)
            {
                facie.FaciePosition = FaciePositionType.RightBottom;
            }
            else if (facie.FaciePosition == FaciePositionType.RightBottom)
            {
                facie.FaciePosition = FaciePositionType.LeftBottom;
            }
        }
    }
}