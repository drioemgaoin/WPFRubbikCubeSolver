﻿using System.Collections.Generic;

namespace RubiksCube.Core.Model.Rotations.YAxis
{
    public class TopLayerLeftRotation : YAxisRotation
    {
        public TopLayerLeftRotation(double angle, uint times) : base(-angle, times)
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
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Right:
                    cube[FaceType.Front].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Left:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
            }
        }
    }
}