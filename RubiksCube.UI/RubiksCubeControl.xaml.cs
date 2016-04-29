using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using RubiksCube.Core;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;
using Point = System.Windows.Point;

namespace RubiksCube.UI
{
    public partial class RubiksCubeControl
    {
        private readonly IPositionsFactory positionsFactory;
        private readonly IRubiksCubeSolver solver;
        private readonly AnimationEngine movementEngine;
        private readonly Cube cube;

        public RubiksCubeControl()
        {
            positionsFactory = new PositionsFactory();
            solver = new FriedrichSolver();
            solver.Move += OnMove;
            movementEngine = new AnimationEngine();
            cube = new Cube();

            DataContext = this;

            InitializeComponent();
            Initialize();

            Loaded += OnLoaded;
        }

        private void OnMove(object sender, UIRotation e)
        {
            Rotate(e);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            movementEngine.Start();
        }

        public void RotateDownFaceCounterClockwise()
        {
            var rotation = cube.Rotate(new DownFaceRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateDownFaceClockwise()
        {
            var rotation = cube.Rotate(new DownFaceRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateUpFaceCounterClockwise()
        {
            var rotation = cube.Rotate(new UpFaceRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateUpFaceClockwise()
        {
            var rotation = cube.Rotate(new UpFaceRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateLeftFaceCounterClockwise()
        {
            var rotation = cube.Rotate(new LeftFaceRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateLeftFaceClockwise()
        {
            var rotation = cube.Rotate(new LeftFaceRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateRightFaceCounterClockwise()
        {
            var rotation = cube.Rotate(new RightFaceRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateRightFaceClockwise()
        {
            var rotation = cube.Rotate(new RightFaceRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateFrontFaceCounterClockwise()
        {
            var rotation = cube.Rotate(new FrontFaceRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateFrontFaceClockwise()
        {
            var rotation = cube.Rotate(new FrontFaceRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateBackFaceCounterClockwise()
        {
            var rotation = cube.Rotate(new BackFaceRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateBackFaceClockwise()
        {
            var rotation = cube.Rotate(new BackFaceRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateCubeOnYAxisCounterClockwise()
        {
            var rotation = cube.Rotate(new YRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateCubeOnYAxisClockwise()
        {
            var rotation = cube.Rotate(new YRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateCubeOnXAxisClockwise()
        {
            var rotation = cube.Rotate(new XRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateCubeOnXAxisCounterClockwise()
        {
            var rotation = cube.Rotate(new XRotationInfo(false));
            Rotate(rotation);
        }

        public void RotateCubeOnZAxisClockwise()
        {
            var rotation = cube.Rotate(new ZRotationInfo(true));
            Rotate(rotation);
        }

        public void RotateCubeOnZAxisCounterClockwise()
        {
            var rotation = cube.Rotate(new ZRotationInfo(false));
            Rotate(rotation);
        }

        public void MixUp()
        {
            foreach(var rotation in cube.Scramble())
            {
                Rotate(rotation);
            }
        }

        private void Rotate(UIRotation rotation)
        {
            var center = GetCenter(false);
            var negateCenter = GetCenter(true);
            foreach (var facies in rotation.Moves)
            {
                var animations = new List<FacieAnimation>();
                var animations1 = new FacieAnimation(center, negateCenter);
                var animations2 = new FacieAnimation(center, negateCenter);
                foreach (var facie in facies)
                {
                    var geometry = group.Children.FirstOrDefault(x => x.GetValue(NameProperty).ToString() == facie.Key);
                    if (geometry != null)
                    {
                        var intermediaryMatrix = facie.PreviousRotation == null ? rotation.Matrix : MatrixHelper.Multiply(facie.PreviousRotation, rotation.Matrix);

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

            Initialize(cube[FaceType.Front]);
            Initialize(cube[FaceType.Left]);
            Initialize(cube[FaceType.Right]);
            Initialize(cube[FaceType.Down]);
            Initialize(cube[FaceType.Up]);
            Initialize(cube[FaceType.Back]);
        }

        private void Initialize(Face face)
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

            //var binding = new Binding("Position");
            //binding.Source = facie;
            //label.SetBinding(Label.ContentProperty, binding);

            var positions = positionsFactory.CreatePositions(type);

            var geometry = new GeometryModel3D
            {
                Geometry = new MeshGeometry3D
                {
                    Positions = CreatePoints(positions, facie.Position),
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
    }
}