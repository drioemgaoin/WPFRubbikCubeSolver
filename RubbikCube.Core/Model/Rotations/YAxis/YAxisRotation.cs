using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.YAxis
{
    internal abstract class YAxisRotation : Rotation
    {
        protected YAxisRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisAdjacentFaces => new[] { FaceType.Front, FaceType.Left, FaceType.Back, FaceType.Right };

        protected void MoveFromFrontToRight(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Right:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Left:
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }

        protected void MoveFromFrontToLeft(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Left:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetRow(LayerType);
        }

        public override double[,] CreateMatrix(double angle)
        {
            return RotationMatrixFactory.CreateYAxisRotation(angle);
        }

        protected override void FlipPosition(Facie facie, FaceType faceType)
        {
            if (facie.Position == FaciePositionType.LeftUp)
            {
                facie.Position = FaciePositionType.RightUp;
            }
            else if (facie.Position == FaciePositionType.RightUp)
            {
                facie.Position = FaciePositionType.LeftUp;
            }
            else if (facie.Position == FaciePositionType.LeftMiddle)
            {
                facie.Position = FaciePositionType.RightMiddle;
            }
            else if (facie.Position == FaciePositionType.RightMiddle)
            {
                facie.Position = FaciePositionType.LeftMiddle;
            }
            else if (facie.Position == FaciePositionType.LeftDown)
            {
                facie.Position = FaciePositionType.RightDown;
            }
            else if (facie.Position == FaciePositionType.RightDown)
            {
                facie.Position = FaciePositionType.LeftDown;
            }
        }
    }
}
