using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RubiksCube.Core.Model
{
    public class Facie : ICloneable, INotifyPropertyChanged
    {
        // TODO: Encapsulate members and use methods to implement the behaviour changing the state

        public string Key { get; set; }

        private FaciePositionType faciePosition;
        public FaciePositionType FaciePosition
        {
            get { return faciePosition; }
            set
            {
                faciePosition = value;
                OnPropertyChanged("FaciePosition");
            }
        }

        public Color Color { get; set; }

        public double[,] PreviousRotation { get; set; }

        public double[,] Rotation { get; set; }

        public object Clone()
        {
            return new Facie
            {
                PreviousRotation = PreviousRotation,
                Rotation = Rotation,
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}