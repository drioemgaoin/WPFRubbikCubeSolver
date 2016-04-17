using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    internal class CubeClockwise : XAxisRotation
    {
        public CubeClockwise(LayerType layerType, double angle, uint times) : base(layerType, angle, times)
        {
        }

        protected override IEnumerable<FaceType> AxisMovingFaces => new[] { FaceType.Right, FaceType.Left };

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Up].Add(facie);
                    break;
                case FaceType.Up:
                    FlipPosition(facie, FaceType.Up);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    cube[FaceType.Down].Add(facie);
                    break;
                case FaceType.Down:
                    FlipPosition(facie, FaceType.Down);
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}
