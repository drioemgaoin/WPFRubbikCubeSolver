using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class FrontLayerRotation : Rotation
    {
        public FrontLayerRotation(string way, double angle, uint times) 
            : base(way, angle, times)
        {
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return RotationMatrixFactory.CreateZRotationMatrix(angle);
        }

        protected override IEnumerable<FaceType> GetMovingFaceTypes()
        {
            return new[] { FaceType.Left, FaceType.Top, FaceType.Right, FaceType.Bottom };
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            if(face.Type == FaceType.Left)
            {
                return face.GetColumnFacies(CubeLayerType.First);
            }

            if(face.Type == FaceType.Right)
            {
                return face.GetColumnFacies(CubeLayerType.Third);
            }

            return face.GetRowFacies(CubeLayerType.First);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation)
        {
            var sourceFace = cube.Find(faceType);
            sourceFace.Remove(facie);

            switch (faceType)
            {
                case FaceType.Left:
                    if (isPositiveRotation)
                    {
                        FlipPosition(facie);
                        cube.TopFace.Add(facie);
                    }
                    else
                    {
                        cube.BottomFace.Add(facie);
                    }
                    break;
                case FaceType.Top:
                    if (isPositiveRotation)
                    {
                        cube.RightFace.Add(facie);
                    }
                    else
                    {
                        cube.FrontFace.Add(facie);
                    }
                    break;
                case FaceType.Right:
                    if (isPositiveRotation)
                    {
                        cube.BottomFace.Add(facie);
                    }
                    else
                    {
                        cube.TopFace.Add(facie);
                    }
                    break;
                case FaceType.Bottom:
                    if (isPositiveRotation)
                    {
                        cube.FrontFace.Add(facie);
                    }
                    else
                    {
                        cube.RightFace.Add(facie);
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
