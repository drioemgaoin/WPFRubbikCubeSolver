using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class FrontLayerLeftRotation : ZAxisRotation
    {
        public FrontLayerLeftRotation(double angle, uint times) : base(-angle, times)
        {
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.Facies;
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            switch (faceType)
            {
                case FaceType.Left:
                    cube[FaceType.Bottom].Add(facie);
                    break;
                case FaceType.Top:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Top].Add(facie);
                    break;
                case FaceType.Bottom:
                    cube[FaceType.Right].Add(facie);
                    break;
            }
        }
    }
}
