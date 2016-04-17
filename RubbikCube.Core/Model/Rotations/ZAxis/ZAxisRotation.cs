using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public abstract class ZAxisRotation : Rotation
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
                        x.FaciePosition == FaciePositionType.LeftDown ||
                        x.FaciePosition == FaciePositionType.LeftMiddle ||
                        x.FaciePosition == FaciePositionType.LeftUp);
                }

                if (face.Type == FaceType.Left)
                {
                    return face.Facies.Where(x =>
                        x.FaciePosition == FaciePositionType.RightDown ||
                        x.FaciePosition == FaciePositionType.RightMiddle ||
                        x.FaciePosition == FaciePositionType.RightUp);
                }

                if (face.Type == FaceType.Down || face.Type == FaceType.Up)
                {
                    return face.Facies.Where(x =>
                        x.FaciePosition == FaciePositionType.LeftDown ||
                        x.FaciePosition == FaciePositionType.MiddleDown ||
                        x.FaciePosition == FaciePositionType.RightDown);
                }

                return face.GetRow(LayerType);
            }

            if (face.Type == FaceType.Right)
            {
                return face.Facies.Where(x =>
                    x.FaciePosition == FaciePositionType.RightDown ||
                    x.FaciePosition == FaciePositionType.RightMiddle ||
                    x.FaciePosition == FaciePositionType.RightUp);
            }

            if (face.Type == FaceType.Left)
            {
                return face.Facies.Where(x =>
                    x.FaciePosition == FaciePositionType.LeftDown ||
                    x.FaciePosition == FaciePositionType.LeftMiddle ||
                    x.FaciePosition == FaciePositionType.LeftUp);
            }

            if (face.Type == FaceType.Down || face.Type == FaceType.Up)
            {
                return face.Facies.Where(x =>
                    x.FaciePosition == FaciePositionType.LeftUp ||
                    x.FaciePosition == FaciePositionType.MiddleUp ||
                    x.FaciePosition == FaciePositionType.RightUp);
            }

            return face.GetRow(LayerType);
        }

        public override double[,] CreateMatrix(double angle)
        {
            return RotationMatrixFactory.CreateZAxisRotation(angle);
        }
    }
}
