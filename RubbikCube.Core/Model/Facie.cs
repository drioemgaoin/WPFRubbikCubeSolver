using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RubiksCube.Core.Model
{
    public class Facie : ICloneable, INotifyPropertyChanged
    {
       private FaciePositionType faciePosition;

        public Facie(Color color)
        {
            Color = color;
        }

        public FaciePositionType FaciePosition
        {
            get { return faciePosition; }
            set
            {
                faciePosition = value;
                OnPropertyChanged("FaciePosition");
            }
        }

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new Facie(Color)
            {
                Key = Key,
                PreviousRotation = PreviousRotation,
                Rotation = Rotation,
                FaciePosition = FaciePosition
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