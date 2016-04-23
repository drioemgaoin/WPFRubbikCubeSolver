namespace RubiksCube.Core.Model.Rotations.XAxis
{
    public class XRotationInfo : RotationInfo
    {
        public XRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public XRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Left;

        public override LayerType Layer => LayerType.All;
    }
}
