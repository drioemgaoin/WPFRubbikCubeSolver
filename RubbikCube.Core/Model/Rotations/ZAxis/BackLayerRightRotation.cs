using System;

namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class BackLayerRightRotation : ZAxisRotation
    {
        public BackLayerRightRotation(double angle, uint times) : base(angle, times)
        {
        }

        protected override LayerType LayerType => LayerType.Third;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
