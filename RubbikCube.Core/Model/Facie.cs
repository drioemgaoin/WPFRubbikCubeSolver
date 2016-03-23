using System;
using System.Text;
using System.Windows.Media;

namespace RubiksCube.Core.Model
{
    public class Facie : ICloneable
    {
        private double[,] rotation;

        public string Key { get; set; }

        public FaciePositionType FaciePosition { get; set; }

        public string ColorName
        {
            get
            {
                if (Color == Colors.Blue)
                {
                    return "Blue";
                }

                if (Color == Colors.Red)
                {
                    return "Red";
                }

                if (Color == Colors.Green)
                {
                    return "Green";
                }

                if (Color == Colors.Orange)
                {
                    return "Orange";
                }

                if (Color == Colors.White)
                {
                    return "White";
                }

                if (Color == Colors.Yellow)
                {
                    return "Yellow";
                }

                return "NA";
            }
        }

        public Color Color { get; set; } // TODO: Replace with new model type to protect integrity and break the UI dependency

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
            buffer.AppendLine(FaciePosition + "-" + ColorName);
            return buffer.ToString();
        }
    }
}