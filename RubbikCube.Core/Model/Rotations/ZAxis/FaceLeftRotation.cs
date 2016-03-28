using System;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class FaceLeftRotation : ZAxisRotation
    {
        public FaceLeftRotation(double angle, uint times) : base(angle, times)
        {
        }

        protected override LayerType LayerType => LayerType.All;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
