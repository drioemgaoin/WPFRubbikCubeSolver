using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WpfApplication.Annotations;
using WpfApplication.Domain;
using WpfApplication.Domain.Enum;
using WpfApplication.Domain.Factory;
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

        private double abscisseAngle;
        private double ordinateAngle;

        public RubbikCube()
        {
            faceService = new FaceService();
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
            faceService.RotateRowRight(1);
        }

        public void RotateRowLeft()
        {
            faceService.RotateRowLeft(1);
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
        }

        public void RotateDown()
        {
            faceService.RotateDown();
        }

        public void RotateLeft()
        {
            faceService.RotateLeft();
        }

        public void RotateRight()
        {
            faceService.RotateRight();
        }

        private void Initialize()
        {
            group.Children.Clear();

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
                var shape = CreateShape(subFace);
                group.Children.Add(shape);
            }

            var transform = new Transform3DGroup();
            transform.Children.Add(CreateRotation(face, "OrdinateAngle", true));
            transform.Children.Add(CreateRotation(face, "AbscisseAngle", false));
            group.Transform = transform;
        }

        private GeometryModel3D CreateShape(Face face)
        {
            var transform = new Transform3DGroup();
            transform.Children.Add(new TranslateTransform3D(-0.5, -0.5, +0.5));
            transform.Children.Add(CreateRotation(face, "OrdinateAngle", true));
            transform.Children.Add(CreateRotation(face, "AbscisseAngle", false));
            transform.Children.Add(CreateRotationZ(face, "DepthAngle"));

            var label = new Label
                {
                    Background = new SolidColorBrush(face.Color),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(1)
                };

            var binding = new Binding
            {
                Source = face,
                Path = new PropertyPath("Type1"),
                Mode = BindingMode.OneWay
            };
            BindingOperations.SetBinding(label, Label.ContentProperty, binding);

            return new GeometryModel3D
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
                Transform = transform//new MatrixTransform3D(CreateMatrix3D(face.))
            };
        }

        private static RotateTransform3D CreateRotation(Face face, string path, bool isRow)
        {
            var rotation = new RotateTransform3D
            {
                Rotation = new AxisAngleRotation3D
                {
                    Axis = new Vector3D(isRow ? 0 : 1, isRow ? 1 : 0, 0),
                }
            };

            var binding = new Binding
            {
                Source = face, 
                Path = new PropertyPath(path), 
                Mode = BindingMode.OneWay
            };
            BindingOperations.SetBinding(rotation.Rotation, AxisAngleRotation3D.AngleProperty, binding);

            return rotation;
        }

        private static RotateTransform3D CreateRotationZ(Face face, string path)
        {
            var rotation = new RotateTransform3D
            {
                Rotation = new AxisAngleRotation3D
                {
                    Axis = new Vector3D(0, 0, 1),
                }
            };

            var binding = new Binding
            {
                Source = face,
                Path = new PropertyPath(path),
                Mode = BindingMode.OneWay
            };
            BindingOperations.SetBinding(rotation.Rotation, AxisAngleRotation3D.AngleProperty, binding);

            return rotation;
        }

        private Matrix3D CreateMatrix3D()
        {
            var matrix = new Matrix3D();
            //matrix.Rotate(new Quaternion(new Vector3D(1, 0, 0), x));
            //matrix.Rotate(new Quaternion(new Vector3D(0, 1, 0) * matrix, y));
            //matrix.Rotate(new Quaternion(new Vector3D(0, 0, 1) * matrix, z));

            return matrix;
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