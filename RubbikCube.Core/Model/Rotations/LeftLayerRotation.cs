using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class LeftLayerRotation : XAxisRotation
    {
        public LeftLayerRotation(bool clockwise, double angle, uint times) : base(clockwise, angle, times)
        {
        }

        protected override IEnumerable<Facie> GetMovingFacies(Face face)
        {
            return face.GetYLayer(LayerType.First);
        }

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            cube[faceType].Remove(facie);

            switch (faceType)
            {
                case FaceType.Front:
                    if (IsClockwise)
                    {
                        cube[FaceType.Top].Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube[FaceType.Bottom].Add(facie);
                    }
                    break;
                case FaceType.Top:
                    if (IsClockwise)
                    {
                        FlipPosition(facie);
                        cube[FaceType.Back].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Front].Add(facie);
                    }
                    break;
                case FaceType.Back:
                    if (IsClockwise)
                    {
                        cube[FaceType.Bottom].Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube[FaceType.Top].Add(facie);
                    }
                    break;
                case FaceType.Bottom:
                    if (IsClockwise)
                    {
                        FlipPosition(facie);
                        cube[FaceType.Front].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Back].Add(facie);
                    }
                    break;
            }
        }
    }
}