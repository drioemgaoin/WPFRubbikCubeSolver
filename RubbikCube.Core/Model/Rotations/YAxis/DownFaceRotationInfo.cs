namespace RubiksCube.Core.Model.Rotations.YAxis
{
    public class DownFaceRotationInfo : RotationInfo
    {
        public DownFaceRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public DownFaceRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Down;

        public override LayerType Layer => LayerType.Third;
    }
}