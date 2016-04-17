namespace RubiksCube.Core.Model.Rotations.ZAxis
{
    public class FrontFaceRotationInfo : RotationInfo
    {
        public FrontFaceRotationInfo(bool clockwise) : base(clockwise)
        {
        }

        public FrontFaceRotationInfo(bool clockwise, uint times) : base(clockwise, times)
        {
        }

        public override FaceType Face => FaceType.Front;

        public override LayerType Layer => LayerType.First;
    }
}