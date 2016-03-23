using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using RubiksCube.Core.Model;
using RubiksCube.Core.Factory;
using Point = System.Windows.Point;

namespace RubiksCube.UI
{
    public partial class RubbikCube : IDisposable
    {
        private readonly IPositionsFactory positionsFactory;
        private readonly ICubeFactory cubeFactory;
        private readonly AnimationEngine movementEngine;
        private Cube cube;
        private bool disposed;

        public RubbikCube()
        {
            positionsFactory = new PositionsFactory();
            cubeFactory = new CubeFactory();
            movementEngine = new AnimationEngine();

            DataContext = this;

            InitializeComponent();
            Initialize();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            movementEngine.Start();    
        }

        public void RotateRowRight(RotationType type)
        {
            var rotation = new Rotation(Rotation.Right, Math.PI / 4, type);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateRowLeft(RotationType type)
        {
            var rotation = new Rotation(Rotation.Left, Math.PI / 4, type);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateColumnUp(RotationType type)
        {
            var rotation = new Rotation(Rotation.Up, Math.PI / 4, type);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateColumnDown(RotationType type)
        {
            var rotation = new Rotation(Rotation.Down, Math.PI / 4, type);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateLeft()
        {
            var rotation = new Rotation(Rotation.Left, Math.PI / 4);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateRight()
        {
            var rotation = new Rotation(Rotation.Right, Math.PI / 4);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateUp()
        {
            var rotation = new Rotation(Rotation.Up, Math.PI / 4);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void RotateDown()
        {
            var rotation = new Rotation(Rotation.Down, Math.PI / 4);
            var movements = cube.Rotate(rotation);
            Rotate(movements);
        }

        public void MixUp()
        {
            var random = new Random();
            for(var i = 0; i < 50; i++)
            {
                var action = random.Next(0, 8);
                switch(action)
                {
                    case 0:
                        RotateRowRight(RotationType.First);
                        break;
                    case 1:
                        RotateRowRight(RotationType.Second);
                        break;
                    case 2:
                        RotateRowRight(RotationType.Third);
                        break;
                    case 3:
                        RotateRowLeft(RotationType.First);
                        break;
                    case 4:
                        RotateRowLeft(RotationType.Second);
                        break;
                    case 5:
                        RotateRowLeft(RotationType.Third);
                        break;
                    case 6:
                        RotateColumnUp(RotationType.First);
                        break;
                    case 7:
                        RotateColumnUp(RotationType.Second);
                        break;
                    case 8:
                        RotateColumnUp(RotationType.Third);
                        break;
                    case 9:
                        RotateColumnDown(RotationType.First);
                        break;
                    case 10:
                        RotateColumnDown(RotationType.Second);
                        break;
                    case 11:
                        RotateColumnDown(RotationType.Third);
                        break;
                }
            }
        }

        private void Rotate(IEnumerable<List<Facie>> items)
        {
            var center = GetCenter(false);
            var negateCenter = GetCenter(true);

            foreach (var facies in items)
            {
                var animations = new FacieAnimation(center, negateCenter);
                foreach (var facie in facies)
                {
                    var geometry = group.Children.FirstOrDefault(x => x.GetValue(NameProperty).ToString() == facie.Key);
                    if (geometry != null)
                    {
                        animations.Add(facie, geometry);
                    }
                }

                movementEngine.BeginAnimation(animations);
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
                var shape = CreateFacie(facie, face.Type);
                group.Children.Add(shape);
            }
        }

        private GeometryModel3D CreateFacie(Facie facie, FaceType type)
        {
            var label = new Label
            {
                Background = new SolidColorBrush(facie.Color),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.3)
            };

            var positions = positionsFactory.CreatePositions(type);

            var geometry = new GeometryModel3D
            {
                Geometry = new MeshGeometry3D
                {
                    Positions = CreatePoints(positions, facie.FaciePosition),
                    TriangleIndices = new Int32Collection { 2, 1, 3, 2, 0, 1 },
                    TextureCoordinates = new PointCollection { new Point(-0.5, -0.5), new Point(0.5, -0.5), new Point(-0.5, 0.5), new Point(0.5, 0.5) }
                },
                Material = new DiffuseMaterial(new VisualBrush
                {
                    Visual = label
                })
            };

            geometry.SetValue(NameProperty, facie.Key);

            return geometry;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    movementEngine.Stop();
                }

                disposed = true;
            }
        }

        ~RubbikCube()
        {
            Dispose(false);
        }
    }
}