using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using RubiksCube.Core;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;
using RubiksCube.Solvers;
using Point = System.Windows.Point;

namespace RubiksCube.UI
{
    public partial class RubiksCubeControl
    {
        private readonly IPositionsFactory positionsFactory;
        private readonly AnimationEngine movementEngine;
        private readonly Cube cube;

        public RubiksCubeControl()
        {
            positionsFactory = new PositionsFactory();
            movementEngine = new AnimationEngine();
            cube = new Cube();
            cube.Moving += CubeMoving;

            DataContext = this;

            InitializeComponent();
            Initialize();

            Loaded += OnLoaded;
        }

        private void CubeMoving(object sender, UIRotation e)
        {
            Rotate(e);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            movementEngine.Start();
        }

        public void RotateDownFaceCounterClockwise()
        {
            cube.Rotate(new DownFaceRotationInfo(false));
        }

        public void RotateDownFaceClockwise()
        {
            cube.Rotate(new DownFaceRotationInfo(true));
        }

        public void RotateUpFaceCounterClockwise()
        {
            cube.Rotate(new UpFaceRotationInfo(false));
        }

        public void RotateUpFaceClockwise()
        {
            cube.Rotate(new UpFaceRotationInfo(true));
        }

        public void RotateLeftFaceCounterClockwise()
        {
            cube.Rotate(new LeftFaceRotationInfo(false));
        }

        public void RotateLeftFaceClockwise()
        {
            cube.Rotate(new LeftFaceRotationInfo(true));
        }

        public void RotateRightFaceCounterClockwise()
        {
            cube.Rotate(new RightFaceRotationInfo(false));
        }

        public void RotateRightFaceClockwise()
        {
            cube.Rotate(new RightFaceRotationInfo(true));            
        }

        public void RotateFrontFaceCounterClockwise()
        {
            cube.Rotate(new FrontFaceRotationInfo(false));
        }

        public void RotateFrontFaceClockwise()
        {
            cube.Rotate(new FrontFaceRotationInfo(true));
        }

        public void RotateBackFaceCounterClockwise()
        {
            cube.Rotate(new BackFaceRotationInfo(false));
        }

        public void RotateBackFaceClockwise()
        {
            cube.Rotate(new BackFaceRotationInfo(true));
        }

        public void RotateCubeOnYAxisCounterClockwise()
        {
            cube.Rotate(new YRotationInfo(false));
        }

        public void RotateCubeOnYAxisClockwise()
        {
            cube.Rotate(new YRotationInfo(true));
        }

        public void RotateCubeOnXAxisClockwise()
        {
            cube.Rotate(new XRotationInfo(true));
        }

        public void RotateCubeOnXAxisCounterClockwise()
        {
            cube.Rotate(new XRotationInfo(false));
        }

        public void RotateCubeOnZAxisClockwise()
        {
            cube.Rotate(new ZRotationInfo(true));
        }

        public void RotateCubeOnZAxisCounterClockwise()
        {
            cube.Rotate(new ZRotationInfo(false));
        }

        public void MixUp()
        {
            cube.Scramble();
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
                }),
                BackMaterial = new DiffuseMaterial(Brushes.Black)
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

        public void Solve()
        {
            var solver = new FriedrichSolver();
            solver.Solve(cube);
        }
    }
}