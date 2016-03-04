using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace RubiksCube.UI
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
        private readonly IPositionsFactory positionsFactory;
        private readonly ICubeFactory cubeFactory;
        private readonly ICubeService cubeService;
        private Cube cube;

        public RubbikCube()
        {
            positionsFactory = new PositionsFactory();
            cubeFactory = new CubeFactory();
            cubeService = new CubeService();
            DataContext = this;

            InitializeComponent();
            Initialize();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RotateRowRight()
        {
            var facies = cubeService.RotateRowOnRightSide(cube, 1);
            Rotate(facies);
        }

        public void RotateRowLeft()
        {
            var facies = cubeService.RotateRowOnLeftSide(cube, 1);
            Rotate(facies);
        }

        public void RotateColumnUp()
        {
            var facies = cubeService.RotateColumnOnUpSide(cube, 1);
            Rotate(facies);
        }

        public void RotateColumnDown()
        {
            var facies = cubeService.RotateColumnOnDownSide(cube, 1);
            Rotate(facies);
        }

        public void RotateLeft()
        {
            var matrix = cubeService.RotateRowOnLeftSide(cube);
            group.Transform = CreateTransformations(matrix);
        }

        public void RotateRight()
        {
            var matrix = cubeService.RotateRowOnRightSide(cube);
            group.Transform = CreateTransformations(matrix);
        }

        public void RotateUp()
        {
            var matrix = cubeService.RotateRowOnUpSide(cube);
            group.Transform = CreateTransformations(matrix);
        }

        public void RotateDown()
        {
            var matrix = cubeService.RotateRowOnDownSide(cube);
            group.Transform = CreateTransformations(matrix);
        }

        private void Rotate(IEnumerable<Face> facies)
        {
            var center = GetCenter(false);
            var negateCenter = GetCenter(true);

            foreach (var facie in facies)
            {
                var key = GetKey(facie);
                var geometry = group.Children.FirstOrDefault(x => x.GetValue(NameProperty).ToString() == key);
                if (geometry != null)
                {
                    geometry.Transform = CreateTransformations(facie.Rotation, center, negateCenter);
                }
            }
        }

        private void Initialize()
        {
            group.Children.Clear();

            cube = cubeFactory.Create();
            InitializeFace(cube.FrontFace);
            InitializeFace(cube.LeftFace);
            InitializeFace(cube.RightFace);
            InitializeFace(cube.BottomFace);
            InitializeFace(cube.TopFace);
            InitializeFace(cube.BackFace);
        }

        private void InitializeFace(Face face)
        {
            foreach (var facie in face.Facies)
            {
                var shape = CreateFacie(facie);
                group.Children.Add(shape);
            }
        }

        private GeometryModel3D CreateFacie(Face facie)
        {
            var label = new Label
            {
                Background = new SolidColorBrush(facie.Color),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.3)
            };

            var positions = positionsFactory.CreatePositions(facie.Type);

            var geometry = new GeometryModel3D
            {
                Geometry = new MeshGeometry3D
                {
                    Positions = CreatePoints(positions, facie.FaciePositionType),
                    TriangleIndices = new Int32Collection { 2, 1, 3, 2, 0, 1 },
                    TextureCoordinates = new PointCollection { new Point(-0.5, -0.5), new Point(0.5, -0.5), new Point(-0.5, 0.5), new Point(0.5, 0.5) }
                },
                Material = new DiffuseMaterial(new VisualBrush
                {
                    Visual = label
                })
            };

            var key = GetKey(facie);
            geometry.SetValue(NameProperty, key);

            return geometry;
        }

        private static Matrix3D CreateMatrix3D(double[,] matrix)
        {
            var matrix3D = new Matrix3D();
            matrix3D.M11 = matrix[0, 0];
            matrix3D.M12 = matrix[0, 1];
            matrix3D.M13 = matrix[0, 2];
            matrix3D.M21 = matrix[1, 0];
            matrix3D.M22 = matrix[1, 1];
            matrix3D.M23 = matrix[1, 2];
            matrix3D.M31 = matrix[2, 0];
            matrix3D.M32 = matrix[2, 1];
            matrix3D.M33 = matrix[2, 2];

            matrix3D.M14 = matrix[3, 0];
            matrix3D.M24 = matrix[3, 1];
            matrix3D.M34 = matrix[3, 2];

            matrix3D.OffsetX = matrix[0, 3];
            matrix3D.OffsetY = matrix[1, 3];
            matrix3D.OffsetZ = matrix[2, 3];

            matrix3D.M44 = matrix[3, 3];
            
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

        private Vector3D GetCenter(bool isNegate)
        {
            var bounds = group.Bounds;
            var center = new Vector3D(bounds.X + (bounds.SizeX / 2),
                                      bounds.Y + (bounds.SizeY / 2),
                                      bounds.Z + (bounds.SizeZ / 2));
            if (isNegate)
            {
                center.Negate();
            }

            return center;
        }

        private Transform3DGroup CreateTransformations(double[,] rotation)
        {
            return CreateTransformations(rotation, GetCenter(false), GetCenter(true));
        }

        private static Transform3DGroup CreateTransformations(double[,] rotation, Vector3D center, Vector3D negateCenter)
        {
            var transformGroup = new Transform3DGroup();
            transformGroup.Children.Add(new TranslateTransform3D(negateCenter));
            transformGroup.Children.Add(new MatrixTransform3D(CreateMatrix3D(rotation)));
            transformGroup.Children.Add(new TranslateTransform3D(center));
            return transformGroup;
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

        private static string GetKey(Face facie)
        {
            return String.Format("{0}{1}", facie.Type, facie.FaciePositionType);
        }
    }
}