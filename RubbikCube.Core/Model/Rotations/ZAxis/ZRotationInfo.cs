namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class ZRotationInfo : RotationInfo
    {
        public ZRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public ZRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Front;

        public override LayerType Layer => LayerType.All;
    }
}
