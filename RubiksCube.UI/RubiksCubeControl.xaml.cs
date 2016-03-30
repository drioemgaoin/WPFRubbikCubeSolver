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
    public partial class RubiksCubeControl
    {
        private const double Angle = Math.PI / 4;

        private readonly IPositionsFactory positionsFactory;
        private readonly IRubiksCubeSolver cubeSolver;
        private readonly AnimationEngine movementEngine;
        private readonly Cube cube;

        public RubiksCubeControl()
        {
            cubeSolver = new RubiksCubeSolver();
            positionsFactory = new PositionsFactory();
            movementEngine = new AnimationEngine();
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

        public void RotateDownLayerLeft()
        {
            var info = new RotationInfo(LayerType.Third, AxisType.Y, false);
            Rotate(info);
        }

        public void RotateDownLayerRight()
        {
            var info = new RotationInfo(LayerType.Third, AxisType.Y, true);
            Rotate(info);
        }

        public void RotateUpLayerLeft()
        {
            var info = new RotationInfo(LayerType.First, AxisType.Y, false);
            Rotate(info);
        }

        public void RotateUpLayerRight()
        {
            var info = new RotationInfo(LayerType.First, AxisType.Y, true);
            Rotate(info);
        }

        public void RotateLeftLayerDown()
        {
            var info = new RotationInfo(LayerType.First, AxisType.X, false);
            Rotate(info);
        }

        public void RotateLeftLayerUp()
        {
            var info = new RotationInfo(LayerType.First, AxisType.X, true);
            Rotate(info);
        }

        public void RotateRightLayerDown()
        {
            var info = new RotationInfo(LayerType.Third, AxisType.X, false);
            Rotate(info);
        }

        public void RotateRightLayerUp()
        {
            var info = new RotationInfo(LayerType.Third, AxisType.X, true);
            Rotate(info);
        }

        public void RotateFrontLayerLeft()
        {
            var info = new RotationInfo(LayerType.First, AxisType.Z, false);
            Rotate(info);
        }

        public void RotateFrontLayerRight()
        {
            var info = new RotationInfo(LayerType.First, AxisType.Z, true);
            Rotate(info);
        }

        public void RotateBackLayerLeft()
        {
            var info = new RotationInfo(LayerType.Third, AxisType.Z, false);
            Rotate(info);
        }

        public void RotateBackLayerRight()
        {
            var info = new RotationInfo(LayerType.Third, AxisType.Z, true);
            Rotate(info);
        }

        public void RotateFaceLeft()
        {
            var info = new RotationInfo(LayerType.All, AxisType.Y, false);
            Rotate(info);
        }

        public void RotateFaceRight()
        {
            var info = new RotationInfo(LayerType.All, AxisType.Y, true);
            Rotate(info);
        }

        public void RotateFaceUp()
        {
            var info = new RotationInfo(LayerType.All, AxisType.X, true);
            Rotate(info);
        }

        public void RotateFaceDown()
        {
            var info = new RotationInfo(LayerType.All, AxisType.X, false);
            Rotate(info);
        }

        public void RotateUpFaceRight()
        {
            var info = new RotationInfo(LayerType.All, AxisType.Z, true);
            Rotate(info);
        }

        public void RotateUpFaceLeft()
        {
            var info = new RotationInfo(LayerType.All, AxisType.Z, false);
            Rotate(info);
        }

        public void MixUp()
        {
            var actions = new Action[]
            {
                () => RotateUpLayerRight(),
                () => RotateUpLayerLeft(),
                () => RotateDownLayerRight(),
                () => RotateDownLayerLeft(),
                () => RotateLeftLayerUp(),
                () => RotateLeftLayerDown(),
                () => RotateRightLayerUp(),
                () => RotateRightLayerDown()
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

        private void Rotate(RotationInfo rotationInfo)
        {
            var rotation = rotationInfo.CreateRotation();
            cube.Rotate(rotation);

            var matrix = rotation.CreateRotationMatrix(Angle);

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

            InitializeFace(cube[FaceType.Front]);
            InitializeFace(cube[FaceType.Left]);
            InitializeFace(cube[FaceType.Right]);
            InitializeFace(cube[FaceType.Down]);
            InitializeFace(cube[FaceType.Up]);
            InitializeFace(cube[FaceType.Back]);
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
    }
}