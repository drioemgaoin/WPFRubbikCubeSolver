using System;
using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class BackLayerRightRotation : ZAxisRotation
    {
        public BackLayerRightRotation(double angle, uint times) : base(-angle, times)
        {
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            throw new NotImplementedException();
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            throw new NotImplementedException();
        }
    }
}
