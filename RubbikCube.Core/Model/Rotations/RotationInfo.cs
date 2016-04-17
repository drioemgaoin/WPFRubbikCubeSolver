namespace RubiksCube.Core.Model.Rotations
{
    public abstract class RotationInfo 
    {
        protected RotationInfo(bool clockwise) : this(clockwise, 1)
        {
        }

        protected RotationInfo(bool clockwise, uint times)
        {
            Clockwise = clockwise;
            Times = times;
        }

        public abstract FaceType Face { get; }

        public abstract LayerType Layer { get; }

        public bool Clockwise { get; }

        public uint Times { get; }

        public override string ToString()
        {
            return string.Format("Face: {0} Layer: {1}, Clockwise: {2}, Times: {3}", Face, Layer, Clockwise, Times);
        }
    }
}