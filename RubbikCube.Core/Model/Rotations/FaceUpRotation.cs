using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class FaceUpRotation : XAxisRotation
    {
        public FaceUpRotation(double angle, uint times) : base(true, angle, times)
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
                case FaceType.Front:
                    cube[FaceType.Top].Add(facie);
                    break;
                case FaceType.Top:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    cube[FaceType.Bottom].Add(facie);
                    break;
                case FaceType.Bottom:
                    FlipPosition(facie);
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}
