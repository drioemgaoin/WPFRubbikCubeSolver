using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using RubiksCube.Core;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;
using Point = System.Windows.Point;

namespace RubiksCube.UI
{
    public partial class RubiksCubeControl : IDisposable
    {
        private const double Angle = Math.PI / 4;

        private readonly IPositionsFactory positionsFactory;
        private readonly IRubiksCubeSolver cubeSolver;
        private readonly IRotationFactory rotationFactory;
        private readonly AnimationEngine movementEngine;
        private readonly Cube cube;
        private bool disposed;

        public RubiksCubeControl()
        {
            cubeSolver = new RubiksCubeSolver();
            positionsFactory = new PositionsFactory();
            movementEngine = new AnimationEngine();
            rotationFactory = new RotationFactory();
            cube = new Cube();

            DataContext = this;

            InitializeComponent();
            Initialize();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            movementEngine.Start();    
        }

        public void RotateRightFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Right, FaceRotation.CounterClockwise, 1);
            Rotate(rotation);
        }

        public void RotateRightFaceBackward()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Right, FaceRotation.Clockwise, 1);
            Rotate(rotation);
        }

        public void RotateLeftFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Left, FaceRotation.CounterClockwise, 1);
            Rotate(rotation);
        }

        public void RotateLeftFaceBackward()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Left, FaceRotation.Clockwise, 1);
            Rotate(rotation);
        }

        public void RotateTopFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Up, FaceRotation.CounterClockwise, 1);
            Rotate(rotation);
        }

        public void RotateTopFaceBackward()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Up, FaceRotation.Clockwise, 1);
            Rotate(rotation);
        }

        public void RotateBottomFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Down, FaceRotation.CounterClockwise, 1);
            Rotate(rotation);
        }

        public void RotateBottomFaceBackward()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Down, FaceRotation.Clockwise, 1);
            Rotate(rotation);
        }

        public void RotateForwardFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Forward, FaceRotation.CounterClockwise, 1);
            Rotate(rotation);
        }

        public void RotateForwardFaceBackward()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.Forward, FaceRotation.Clockwise, 1);
            Rotate(rotation);
        }

        public void RotateLeftWholeFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.LeftWhole, 1);
            Rotate(rotation);
        }

        public void RotateRightWholeFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.RightWhole, 1);
            Rotate(rotation);
        }

        public void RotateUpWholeFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.UpWhole, 1);
            Rotate(rotation);
        }

        public void RotateDownWholeFace()
        {
            var rotation = rotationFactory.CreateRotation(FaceRotation.DownWhole, 1);
            Rotate(rotation);
        }

        public void MixUp()
        {
            var actions = new Action[]
            {
                () => RotateRightFace(),
                () => RotateLeftFace(),
                () => RotateTopFace(),
                () => RotateBottomFace(),
            };

            var random = new Random();
            for (var i = 0; i < 50; i++)
            {
                var index = random.Next(0, actions.Count());
                actions[index]();
            }
        }

        public void Resolve()
        {
            cubeSolver.Solve(cube);
        }

        private void Rotate(FaceRotation rotation)
        {
            cube.Rotate(rotation);

            var matrix = rotation.GetRotationMatrix(rotation.Way == FaceRotation.CounterClockwise ? Angle : -Angle);

            var center = GetCenter(false);
            var negateCenter = GetCenter(true);
            foreach (var facies in rotation.Movements)
            {
                var animations = new List<FacieAnimation>();
                var animations1 = new FacieAnimation(center, negateCenter);
                var animations2 = new FacieAnimation(center, negateCenter);
                foreach (var facie in facies)
                {
                    var geometry = group.Children.FirstOrDefault(x => x.GetValue(NameProperty).ToString() == facie.Key);
                    if (geometry != null)
                    {
                        var intermediaryMatrix = facie.PreviousRotation == null ? matrix : MatrixHelper.Multiply(facie.PreviousRotation, matrix);

                        var previousMatrix3D = facie.PreviousRotation == null ? Matrix3D.Identity : MatrixMapper.Map(facie.PreviousRotation);
                        var newMatrix3D = MatrixMapper.Map(intermediaryMatrix);
                        animations1.Add(previousMatrix3D, newMatrix3D, geometry);

                        previousMatrix3D = MatrixMapper.Map(intermediaryMatrix);
                        newMatrix3D = MatrixMapper.Map(facie.Rotation);
                        animations2.Add(previousMatrix3D, newMatrix3D, geometry);
                    }
                }

                animations.Add(animations1);
                animations.Add(animations2);

                movementEngine.BeginAnimation(animations);
            }
        }

        private void Initialize()
        {
            group.Children.Clear();

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
                Background = new SolidColorBrush(ColorMapper.Map(facie.Color)),
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
                }

                disposed = true;
            }
        }
    }
}