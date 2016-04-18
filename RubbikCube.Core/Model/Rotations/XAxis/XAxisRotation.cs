using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal abstract class XAxisRotation : Rotation
    {
        protected XAxisRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisAdjacentFaces => new[] { FaceType.Front, FaceType.Up, FaceType.Back, FaceType.Down };

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetColumn(LayerType);
        }

        public override double[,] CreateMatrix(double angle)
        {
            return RotationMatrixFactory.CreateXAxisRotation(angle);
        }

        protected override void FlipPosition(Facie facie, FaceType faceType)
        {
            if (facie.Position == FaciePositionType.MiddleUp)
            {
                facie.Position = FaciePositionType.MiddleDown;
            }
            else if (facie.Position == FaciePositionType.MiddleDown)
            {
                facie.Position = FaciePositionType.MiddleUp;
            }
            else if (facie.Position == FaciePositionType.RightUp)
            {
                facie.Position = FaciePositionType.RightDown;
            }
            else if (facie.Position == FaciePositionType.RightDown)
            {
                facie.Position = FaciePositionType.RightUp;
            }
        }
    }
}
