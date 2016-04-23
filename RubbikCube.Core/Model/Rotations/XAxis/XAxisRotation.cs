using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal abstract class XAxisRotation : Rotation
    {
        protected XAxisRotation(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisAdjacentFaces => new[] { FaceType.Front, FaceType.Up, FaceType.Back, FaceType.Down };

        protected void MoveFromFrontToUp(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Up:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Down:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }

        protected void MoveFromFrontToDown(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Up:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie, faceType);
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Down:
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetColumn(LayerType);
        }

        public override double[,] CreateMatrix(double angle)
        {
            return RotationMatrixFactory.CreateXAxisRotation(angle);
        }        
    }
}
