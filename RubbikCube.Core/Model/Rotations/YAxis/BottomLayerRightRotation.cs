﻿namespace RubiksCube.Core.Model.Rotations.YAxis
{
    public class BottomLayerRightRotation : YAxisRotation
    {
        public BottomLayerRightRotation(double angle, uint times) : base(angle, times)
        {
        }

        protected override LayerType LayerType => LayerType.Third;

        protected override void Move(Cube cube, FaceType faceType, Facie facie)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    cube[FaceType.Right].Add(facie);
                    break;
                case FaceType.Right:
                    FlipPosition(facie);
                    cube[FaceType.Back].Add(facie);
                    break;
                case FaceType.Back:
                    FlipPosition(facie);
                    cube[FaceType.Left].Add(facie);
                    break;
                case FaceType.Left:
                    cube[FaceType.Front].Add(facie);
                    break;
            }
        }
    }
}