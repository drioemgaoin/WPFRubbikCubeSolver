using System;
using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class FaceLeftRotation : ZAxisRotation
    {
        public FaceLeftRotation(double angle, uint times) : base(-angle, times)
        {
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.Facies;
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            throw new NotImplementedException();
        }
    }
}
