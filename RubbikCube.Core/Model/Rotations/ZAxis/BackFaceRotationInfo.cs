namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class BackFaceRotationInfo : RotationInfo
    {
        public BackFaceRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public BackFaceRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Back;

        public override LayerType Layer => LayerType.Third;
    }
}