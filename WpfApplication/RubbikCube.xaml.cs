using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using RubiksCube.Entity;
using RubiksCube.Enums;
using RubiksCube.Factory;
using RubiksCube.Service;
using WpfApplication.Annotations;
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
        private readonly IRotationService rotationService;

        public RubbikCube()
        {
            rotationService = new RotationService();
            faceService = new FaceService();
            positionsFactory = new PositionsFactory();
            DataContext = this;

            InitializeComponent();
            Initialize();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RotateRowRight()
        {
            
        }

        public void RotateRowLeft()
        {
        }

        public void RotateColumnUp()
        {
        }

        public void RotateColumnDown()
        {
        }

        public void RotateLeft()
        {
            var matrix = rotationService.RotationLeft(-45);
            group.Transform = new MatrixTransform3D(CreateMatrix3D(matrix));
        }

        public void RotateRight()
        {
            var matrix = rotationService.RotationRight(45);
            group.Transform = new MatrixTransform3D(CreateMatrix3D(matrix));
        }

        public void RotateUp()
        {
            var matrix = rotationService.RotationUp(45);
            group.Transform = new MatrixTransform3D(CreateMatrix3D(matrix));
        }

        public void RotateDown()
        {
            var matrix = rotationService.RotationDown(45);
            group.Transform = new MatrixTransform3D(CreateMatrix3D(matrix));
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
                var shape = CreateFacie(subFace);
                group.Children.Add(shape);
            }
        }

        private GeometryModel3D CreateFacie(Face face)
        {
            var label = new Label
            {
                Background = new SolidColorBrush(face.Color),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };

            var positions = positionsFactory.CreatePositions(face.Type, face.FaciePositionType);

            var geometry = new GeometryModel3D
            {
                Geometry = new MeshGeometry3D
                {
                    Positions = CreatePoints(positions, face.FaciePositionType),
                    TriangleIndices = new Int32Collection { 2, 1, 3, 2, 0, 1 },
                    TextureCoordinates = new PointCollection { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1,1)}
                },
                Material = new DiffuseMaterial(new VisualBrush
                {
                    Visual = label
                })
            };

            return geometry;
        }

        private static Matrix3D CreateMatrix3D(Func<double>[,] matrix)
        {
            var matrix3D = new Matrix3D();
            matrix3D.M11 = matrix[0, 0]();
            matrix3D.M12 = matrix[0, 1]();
            matrix3D.M13 = matrix[0, 2]();
            matrix3D.M21 = matrix[1, 0]();
            matrix3D.M22 = matrix[1, 1]();
            matrix3D.M23 = matrix[1, 2]();
            matrix3D.M31 = matrix[2, 0]();
            matrix3D.M32 = matrix[2, 1]();
            matrix3D.M33 = matrix[2, 2]();

            matrix3D.M14 = matrix[3, 0]();
            matrix3D.M24 = matrix[3, 1]();
            matrix3D.M34 = matrix[3, 2]();

            matrix3D.OffsetX = matrix[0, 3]();
            matrix3D.OffsetY = matrix[1, 3]();
            matrix3D.OffsetZ = matrix[2, 3]();
            return matrix3D;
        }

        private static Point3DCollection CreatePoints(IDictionary<FaciePositionType, string> positions, FaciePositionType positionType)
        {
            var points = new Point3DCollection();

            var position = System.Text.RegularExpressions.Regex.Split(positions[positionType], @"\s{2}");

            for (var i = 0; i < position.Length; i++)
            {
                var values = position[i].Split(' ');

                var point = new Point3D(
                    Convert.ToDouble(values[0]),
                    Convert.ToDouble(values[1]),
                    Convert.ToDouble(values[2])
                );

                points.Add(point);
            }

            return points;
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