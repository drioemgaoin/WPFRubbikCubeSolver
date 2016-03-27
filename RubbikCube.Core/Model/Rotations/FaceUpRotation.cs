using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class FaceUpRotation : FaceRotation
    {
        public FaceUpRotation(double angle, uint times) : base(CounterClockwise, angle, times)
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

        protected override void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation)
        {
            var sourceFace = cube.Find(faceType);
            sourceFace.Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    cube.TopFace.Add(facie);
                    break;
                case FaceType.Top:
                    FlipPosition(facie);
                    cube.BackFace.Add(facie);
                    break;
                case FaceType.Back:
                    cube.BottomFace.Add(facie);
                    break;
                case FaceType.Bottom:
                    FlipPosition(facie);
                    cube.FrontFace.Add(facie);
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
