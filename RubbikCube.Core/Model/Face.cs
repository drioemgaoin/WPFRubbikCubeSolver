using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Model
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
                return FaciePositionType.ToString();
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

        // TODO: put in place a abstraction
        public void Move(FaceType target)
        {
            if ((Type == FaceType.Back && target == FaceType.Top) ||
                (Type == FaceType.Front && target == FaceType.Bottom) ||
                (Type == FaceType.Bottom && target == FaceType.Front) ||
                (Type == FaceType.Top && target == FaceType.Back))
            {
                switch (FaciePositionType)
                {
                    case FaciePositionType.LeftTop:
                        FaciePositionType = FaciePositionType.LeftBottom;
                        break;
                    case FaciePositionType.LeftBottom:
                        FaciePositionType = FaciePositionType.LeftTop;
                        break;
                    case FaciePositionType.MiddleTop:
                        FaciePositionType = FaciePositionType.MiddleBottom;
                        break;
                    case FaciePositionType.MiddleBottom:
                        FaciePositionType = FaciePositionType.MiddleTop;
                        break;
                    case FaciePositionType.RightTop:
                        FaciePositionType = FaciePositionType.RightBottom;
                        break;
                    case FaciePositionType.RightBottom:
                        FaciePositionType = FaciePositionType.RightTop;
                        break;
                }
            }

            if ((Type == FaceType.Back && target == FaceType.Left) ||
                (Type == FaceType.Right && target == FaceType.Back) ||
                (Type == FaceType.Back && target == FaceType.Right) ||
                (Type == FaceType.Left && target == FaceType.Back))
            {
                switch (FaciePositionType)
                {
                    case FaciePositionType.LeftTop:
                        FaciePositionType = FaciePositionType.RightTop;
                        break;
                    case FaciePositionType.RightTop:
                        FaciePositionType = FaciePositionType.LeftTop;
                        break;
                    case FaciePositionType.LeftMiddle:
                        FaciePositionType = FaciePositionType.RightMiddle;
                        break;
                    case FaciePositionType.RightMiddle:
                        FaciePositionType = FaciePositionType.LeftMiddle;
                        break;
                    case FaciePositionType.LeftBottom:
                        FaciePositionType = FaciePositionType.RightBottom;
                        break;
                    case FaciePositionType.RightBottom:
                        FaciePositionType = FaciePositionType.LeftBottom;
                        break;
                }
            }

            Type = target;
        }

        // TODO: extend new decorator for those methods and create debug factory
        public event PropertyChangedEventHandler PropertyChanged;

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine(Type + "-" + faciePositionType + "-" + ColorName + "=" + Facies.Count);
            foreach (var face in Facies)
            {
                buffer.AppendLine("-->" + face);
            }

            return buffer.ToString();
        }
        // FOR TODO
    }
}