using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class BottomLayerRotation : Rotation
    {
        public BottomLayerRotation(string way, double angle, uint times)
            : base(way, angle, times)
        {
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return RotationMatrixFactory.CreateXRotationMatrix(angle);
        }

        protected override IEnumerable<FaceType> GetMovingFaceTypes()
        {
            return new[] { FaceType.Front, FaceType.Left, FaceType.Back, FaceType.Right };
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetRowFacies(CubeLayerType.Third);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation)
        {
            var sourceFace = cube.Find(faceType);
            sourceFace.Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    if (isPositiveRotation)
                    {
                        cube.RightFace.Add(facie);
                    }
                    else
                    {
                        cube.LeftFace.Add(facie);
                    }
                    break;
                case FaceType.Right:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.BackFace.Add(facie);
                    }
                    else
                    {
                        cube.FrontFace.Add(facie);
                    }
                    break;
                case FaceType.Back:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.LeftFace.Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube.RightFace.Add(facie);
                    }
                    break;
                case FaceType.Left:
                    if (isPositiveRotation)
                    {
                        cube.FrontFace.Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube.BackFace.Add(facie);
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