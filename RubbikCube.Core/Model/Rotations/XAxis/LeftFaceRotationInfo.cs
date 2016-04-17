namespace RubiksCube.Core.Model.Rotations.XAxis
{
    public class LeftFaceRotationInfo : RotationInfo
    {
        public LeftFaceRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public LeftFaceRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Left;

        public override LayerType Layer => LayerType.First;
    }
}