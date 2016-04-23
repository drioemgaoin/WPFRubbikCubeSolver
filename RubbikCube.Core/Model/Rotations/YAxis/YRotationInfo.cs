namespace RubiksCube.Core.Model.Rotations.YAxis
{
    public class YRotationInfo : RotationInfo
    {
        public YRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public YRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Up;

        public override LayerType Layer => LayerType.All;
    }
}
