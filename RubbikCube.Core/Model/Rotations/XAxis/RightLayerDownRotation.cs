using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.XAxis
{
    public class RightLayerDownRotation : XAxisRotation
    {
        public RightLayerDownRotation(double angle, uint times) : base(angle, times)
        {
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetYLayer(LayerType.Third);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    FlipPosition(facie);
                    cube[FaceType.Bottom].Add(facie);
                    break;
                case FaceType.Top:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Top].Add(facie);
                    break;
                case FaceType.Bottom:
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }
    }
}