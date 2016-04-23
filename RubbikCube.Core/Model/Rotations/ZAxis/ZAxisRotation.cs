using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    internal abstract class ZAxisRotation : Rotation
    {
        protected ZAxisRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisAdjacentFaces => new[] { FaceType.Left, FaceType.Up, FaceType.Right, FaceType.Down };

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            if(LayerType == LayerType.First)
            {
                if (face.Type == FaceType.Right)
                {
                    return face.Facies.Where(x =>
                        x.Position == FaciePositionType.LeftDown ||
                        x.Position == FaciePositionType.LeftMiddle ||
                        x.Position == FaciePositionType.LeftUp);
                }

                if (face.Type == FaceType.Left)
                {
                    return face.Facies.Where(x =>
                        x.Position == FaciePositionType.RightDown ||
                        x.Position == FaciePositionType.RightMiddle ||
                        x.Position == FaciePositionType.RightUp);
                }

                if (face.Type == FaceType.Down || face.Type == FaceType.Up)
                {
                    return face.Facies.Where(x =>
                        x.Position == FaciePositionType.LeftDown ||
                        x.Position == FaciePositionType.MiddleDown ||
                        x.Position == FaciePositionType.RightDown);
                }

                return face.GetRow(LayerType);
            }

            if (face.Type == FaceType.Right)
            {
                return face.Facies.Where(x =>
                    x.Position == FaciePositionType.RightDown ||
                    x.Position == FaciePositionType.RightMiddle ||
                    x.Position == FaciePositionType.RightUp);
            }

            if (face.Type == FaceType.Left)
            {
                return face.Facies.Where(x =>
                    x.Position == FaciePositionType.LeftDown ||
                    x.Position == FaciePositionType.LeftMiddle ||
                    x.Position == FaciePositionType.LeftUp);
            }

            if (face.Type == FaceType.Down || face.Type == FaceType.Up)
            {
                return face.Facies.Where(x =>
                    x.Position == FaciePositionType.LeftUp ||
                    x.Position == FaciePositionType.MiddleUp ||
                    x.Position == FaciePositionType.RightUp);
            }

            return face.GetRow(LayerType);
        }

        public override double[,] CreateMatrix(double angle)
        {
            return RotationMatrixFactory.CreateZAxisRotation(angle);
        }
    }
}
