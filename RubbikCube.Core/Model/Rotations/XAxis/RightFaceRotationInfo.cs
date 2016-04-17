namespace RubiksCube.Core.Model.Rotations.XAxis
{
    public class RightFaceRotationInfo : RotationInfo
    {
        public RightFaceRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public RightFaceRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Right;

        public override LayerType Layer => LayerType.Third;
    }
}