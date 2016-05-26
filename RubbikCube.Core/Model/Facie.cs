using System;
using System.ComponentModel;
using System.Text;

namespace RubiksCube.Core.Model
{
    public class Facie : ICloneable, INotifyPropertyChanged
    {
        public Facie(Color color) // TODO: remove this overload
        {
            Color = color;  
        }

        public Facie(Color color, FaciePositionType position)
        {
            Color = color;
            Position = position;
        }

        public FaciePositionType Position { get; set; }

        public Color Color { get; }

        public string Key { get; set; }

        public double[,] PreviousRotation { get; private set; }

        public double[,] Rotation { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetRotation(double[,] matrix)
        {
            PreviousRotation = Rotation;
            Rotation = Rotation == null ? matrix : MatrixHelper.Multiply(Rotation, matrix);
        }

        public object Clone()
        {
            return new Facie(Color)
            {
                Key = Key,
                PreviousRotation = PreviousRotation,
                Rotation = Rotation,
                Position = Position
            };
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine(Position + "-" + Color);

            return buffer.ToString();
        }               
    }
}