using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public abstract class FaceRotation : Rotation
    {
        protected FaceRotation(string way, double angle, uint times) : base(way, angle, times)
        {
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetColumnFacies(CubeLayerType.All);
        }
    }
}
