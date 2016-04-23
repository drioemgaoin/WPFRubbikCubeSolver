namespace RubiksCube.Core.Model.Rotations.YAxis
{
    public class UpFaceRotationInfo : RotationInfo
    {
        public UpFaceRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public UpFaceRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Up;

        public override LayerType Layer => LayerType.First;
    }
}