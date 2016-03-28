using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations
{
    public class BottomLayerRotation : YAxisRotation
    {
        public BottomLayerRotation(bool clockwise, double angle, uint times) : base(clockwise, angle, times)
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
                    if (IsClockwise)
                    {
                        cube[FaceType.Right].Add(facie);
                    }
                    else
                    {
                        cube[FaceType.Left].Add(facie);
                    }
                    break;
                case FaceType.Right:
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
                        FlipPosition(facie);
                        cube[FaceType.Left].Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube[FaceType.Right].Add(facie);
                    }
                    break;
                case FaceType.Left:
                    if (IsClockwise)
                    {
                        cube[FaceType.Front].Add(facie);
                    }
                    else
                    {
                        FlipPosition(facie);
                        cube[FaceType.Back].Add(facie);
                    }
                    break;
            }
        }
    }
}