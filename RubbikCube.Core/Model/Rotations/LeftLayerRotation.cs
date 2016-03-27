using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class LeftLayerRotation : Rotation
    {
        public LeftLayerRotation(string way, double angle, uint times)
            : base(way, angle, times)
        {
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return RotationMatrixFactory.CreateYRotationMatrix(angle);
        }

        protected override IEnumerable<FaceType> GetMovingFaceTypes()
        {
            return new[] { FaceType.Front, FaceType.Top, FaceType.Back, FaceType.Bottom };
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetColumnFacies(CubeLayerType.First);
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
                        cube.TopFace.Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube.BottomFace.Add(facie);
                    }
                    break;
                case FaceType.Top:
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
                        cube.BottomFace.Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube.TopFace.Add(facie);
                    }
                    break;
                case FaceType.Bottom:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.FrontFace.Add(facie);
                    }
                    else
                    {
                        cube.BackFace.Add(facie);
                    }
                    break;
            }
        }

        // TODO: same method for rignt/left face rotation -> create abstraction
        private static void FlipPosition(Facie facie)
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