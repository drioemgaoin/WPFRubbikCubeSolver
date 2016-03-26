using System.Collections.Generic;

namespace RubiksCube.Core.Model
{
    public class DownWholeFaceRotation : FaceRotation
    {
        public DownWholeFaceRotation(double angle, uint times)
            : base(Clockwise, angle, times)
        {
        }

        public override double[,] GetRotationMatrix(double angle)
        {
            return rotationMatrixFactory.CreateYRotationMatrix(angle);
        }

        protected override IEnumerable<FaceType> GetImpactedFaceTypes()
        {
            return new[] { FaceType.Front, FaceType.Top, FaceType.Back, FaceType.Bottom };
        }

        protected override IEnumerable<Facie> GetImpactedFacies(Face face)
        {
            return face.GetColumnFacies(RotationType.All);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation)
        {
            var sourceFace = cube.Find(faceType);
            sourceFace.Facies.Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    FlipPosition(facie);
                    cube.BottomFace.Facies.Add(facie);
                    break;
                case FaceType.Top:
                    cube.FrontFace.Facies.Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube.TopFace.Facies.Add(facie);
                    break;
                case FaceType.Bottom:
                    cube.BackFace.Facies.Add(facie);
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
