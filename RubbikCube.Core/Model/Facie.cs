using System;
using System.Text;

namespace RubiksCube.Core.Model
{
    public class Facie : ICloneable
    {
        private double[,] rotation;

        public string Key { get; set; }

        public FaciePositionType FaciePosition { get; set; }

        public Color Color { get; set; }

        public double[,] PreviousRotation { get; private set; }

        public double[,] Rotation
        {
            get { return rotation; }
            set
            {
                if (rotation != null)
                {
                    PreviousRotation = MatrixHelper.Copy(rotation);
                }

                rotation = value;
            }
        }

        public object Clone()
        {
            return new Facie
            {
                PreviousRotation = PreviousRotation,
                rotation = Rotation,
                Key = Key,
                FaciePosition = FaciePosition,
                Color = Color
            };
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine(FaciePosition + "-" + Color);
            return buffer.ToString();
        }
    }
}