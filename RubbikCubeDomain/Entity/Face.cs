using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using RubiksCube.Enums;

namespace RubiksCube.Entity
{
    public class Face : INotifyPropertyChanged
    {
        private FaceType type;
        private FaciePositionType faciePositionType;

        public Face()
        {
            Facies = new List<Face>();
        }

        public double[,] Rotation { get; set; }

        public string Key { get; set; }

        public string Type2
        {
            get
            {
                return Type.ToString();//String.Format("{0} {1}", Type, FaciePositionType); 
            }
        }

        public FaceType Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type2");
            }
        }

        public FaciePositionType FaciePositionType
        {
            get { return faciePositionType; }
            set
            {
                faciePositionType = value;
                OnPropertyChanged("Type2");
            }
        }

        public Color Color { get; set; } // TODO: Replace with new model type to protect integrity and break the UI dependency

        public IList<Face> Facies { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}