using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WpfApplication.Annotations;
using WpfApplication.Domain;
using WpfApplication.Domain.Enum;
using WpfApplication.Domain.Factory;
using WpfApplication.Domain.Service;
using Point = System.Windows.Point;

namespace WpfApplication
{
    public interface IRubbikCube
    {
        void RotateUp();
        void RotateDown();
        void RotateLeft();
        void RotateRight();
    }

    public partial class RubbikCube : IRubbikCube, INotifyPropertyChanged
    {
        private readonly IFaceService faceService;
        private readonly IPositionsFactory positionsFactory;
        private readonly IAxisService axisService;

        private double abscisseAngle;
        private double ordinateAngle;

        public RubbikCube()
        {
            axisService = new AxisService();
            faceService = new FaceService(axisService);
            positionsFactory = new PositionsFactory();
            DataContext = this;

            InitializeComponent();
            Initialize();
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
        
        public void RotateRowRight()
        {
            faceService.RotateRowRight(0);
            RotateFacies();
        }

        public void RotateRowLeft()
        {
            faceService.RotateRowLeft(0);
            RotateFacies();
        }

        public void RotateColumnUp()
        {
            faceService.RotateColumnUp(0);
        }

        public void RotateColumnDown()
        {
            faceService.RotateColumnDown(0);
        }

        public void RotateUp()
        {
            faceService.RotateUp();
            Rotate();
        }

        public void RotateDown()
        {
            faceService.RotateDown();
            Rotate();
        }

        public void RotateLeft()
        {
            faceService.RotateLeft();
            Rotate();
        }

        public void RotateRight()
        {
            faceService.RotateRight();
            Rotate();
        }

        private void Initialize()
        {
            group.Children.Clear();

            axisService.Create(FaceType.None, FaciePositionType.None);

            InitializeFace(FaceType.Front);
            InitializeFace(FaceType.Top);
            InitializeFace(FaceType.Bottom);
            InitializeFace(FaceType.Left);
            InitializeFace(FaceType.Right);
            InitializeFace(FaceType.Back);
        }

        private void InitializeFace(FaceType type)
        {
            var face = faceService.CreateFace(type);
            foreach (var subFace in face.Facies)
            {
                var shape = CreateFacie(subFace);
                group.Children.Add(shape);
            }

            var matrix = new Matrix3D();
            matrix.Translate(new Vector3D(-0.5, -0.5, +0.5));
            group.Transform = new MatrixTransform3D(matrix);
        }

        private GeometryModel3D CreateFacie(Face face)
        {
            var label = new Label
            {
                Background = new SolidColorBrush(face.Color),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };

            var axes = axisService.Create(face.Type, face.FaciePositionType);

            var matrix = new Matrix3D();
            matrix.Rotate(new Quaternion(axes.AxisX.Vector, axes.AxisX.Angle));
            matrix.Rotate(new Quaternion(axes.AxisY.Vector * matrix, axes.AxisY.Angle));
            matrix.Rotate(new Quaternion(axes.AxisZ.Vector * matrix, axes.AxisZ.Angle));

            var geometry = new GeometryModel3D
            {
                Geometry = new MeshGeometry3D
                {
                    Positions = positionsFactory.CreatePoints(face.Type, face.FaciePositionType),
                    TriangleIndices = new Int32Collection { 2, 1, 3, 2, 0, 1 },
                    TextureCoordinates = new PointCollection { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1,1)}
                },
                Material = new DiffuseMaterial(new VisualBrush
                {
                    Visual = label
                }),
                Transform = new MatrixTransform3D(matrix)
            };

            geometry.SetValue(NameProperty, String.Format("{0}dash{1}", face.Type, face.FaciePositionType));

            return geometry;
        }

        private void Rotate()
        {
            var axes = axisService.Get(FaceType.None, FaciePositionType.None);

            var matrix = new Matrix3D();
            matrix.Translate(new Vector3D(-0.5, -0.5, +0.5));
            matrix.Rotate(new Quaternion(axes.AxisX.Vector, axes.AxisX.Angle));
            matrix.Rotate(new Quaternion(axes.AxisY.Vector * matrix, axes.AxisY.Angle));
            matrix.Rotate(new Quaternion(axes.AxisZ.Vector * matrix, axes.AxisZ.Angle));
            group.Transform = new MatrixTransform3D(matrix);
        }

        private void RotateFacies()
        {
            foreach (var geometry in group.Children.Cast<GeometryModel3D>())
            {
                var name = geometry.GetValue(NameProperty).ToString().Replace("dash", " ").Split(' ');
                var faceType = (FaceType)Enum.Parse(typeof (FaceType), name[0]);
                var faciePositionType = (FaciePositionType)Enum.Parse(typeof (FaciePositionType), name[1]);

                var axes = axisService.Get(faceType, faciePositionType);

                var matrix = new Matrix3D();
                matrix.Rotate(new Quaternion(axes.AxisX.Vector, axes.AxisX.Angle));
                matrix.Rotate(new Quaternion(axes.AxisY.Vector * matrix, axes.AxisY.Angle));
                matrix.Rotate(new Quaternion(axes.AxisZ.Vector * matrix, axes.AxisZ.Angle));
                geometry.Transform = new MatrixTransform3D(matrix);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}