using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using WpfApplication.Annotations;
using WpfApplication.Domain.Enum;

namespace WpfApplication.Domain
{
    public class Face: INotifyPropertyChanged
    {
        private double abscisseAngle;
        private double ordinateAngle;
        private double depthAngle;
        private FaceType type;

        public Face()
        {
            Facies = new List<Face>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double AbscisseAngle
        {
            get { return abscisseAngle; }
            set
            {
                if (value != abscisseAngle)
                {
                    abscisseAngle = value;
                    NotifyPropertyChanged("AbscisseAngle");
                }
            }
        }

        public double OrdinateAngle
        {
            get { return ordinateAngle; }
            set
            {
                if (value != ordinateAngle)
                {
                    ordinateAngle = value;
                    NotifyPropertyChanged("OrdinateAngle");
                }
            }
        }

        public double DepthAngle
        {
            get { return depthAngle; }
            set
            {
                if (value != depthAngle)
                {
                    depthAngle = value;
                    NotifyPropertyChanged("DepthAngle");
                }
            }
        }

        public string Type1
        {
            get { return type.ToString() + "-" + 
                (int)FaciePositionType; }
        }

        public FaceType Type
        {
            get { return type; }
            set
            {
                if (value != type)
                {
                    type = value;
                    NotifyPropertyChanged("Type1");
                }
            }
        }

        //public FaceType Type { get; set; }

        public FaciePositionType FaciePositionType { get; set; }

        public Color Color { get; set; }

        public IList<Face> Facies { get; set; }

        public IEnumerable<Face> GetRow(int index)
        {
            switch (index)
            {
                case 0:
                    return Facies.Where(x => x.FaciePositionType == FaciePositionType.RightTop
                                        || x.FaciePositionType == FaciePositionType.MiddleTop
                                        || x.FaciePositionType == FaciePositionType.LeftTop);
                case 1:
                    return Facies.Where(x => x.FaciePositionType == FaciePositionType.RightMiddle
                                        || x.FaciePositionType == FaciePositionType.Middle
                                        || x.FaciePositionType == FaciePositionType.LeftMiddle);
                case 2:
                    return Facies.Where(x => x.FaciePositionType == FaciePositionType.RightBottom
                                        || x.FaciePositionType == FaciePositionType.MiddleBottom
                                        || x.FaciePositionType == FaciePositionType.LeftBottom);
            }

            return null;
        }

        public IEnumerable<Face> GetColumn(int index)
        {
            switch (index)
            {
                case 0:
                    return Facies.Where(x => x.FaciePositionType == FaciePositionType.LeftTop
                                        || x.FaciePositionType == FaciePositionType.LeftMiddle
                                        || x.FaciePositionType == FaciePositionType.LeftBottom);
                case 1:
                    return Facies.Where(x => x.FaciePositionType == FaciePositionType.MiddleTop
                                        || x.FaciePositionType == FaciePositionType.Middle
                                        || x.FaciePositionType == FaciePositionType.MiddleBottom);
                case 2:
                    return Facies.Where(x => x.FaciePositionType == FaciePositionType.RightTop
                                        || x.FaciePositionType == FaciePositionType.RightMiddle
                                        || x.FaciePositionType == FaciePositionType.RightBottom);
            }

            return null;
        }

        [NotifyPropertyChangedInvocator]
        protected void NotifyPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}