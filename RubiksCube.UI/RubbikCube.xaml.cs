using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using RubiksCube.Core.Model;
using RubiksCube.Core.Factory;
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
        private Cube cube;

        public RubbikCube()
        {
            positionsFactory = new PositionsFactory();
            cubeFactory = new CubeFactory();
            DataContext = this;

            InitializeComponent();
            Initialize();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RotateRowRight()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Right, RotationType.First));
            foreach(var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateRowLeft()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Left, RotationType.First));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateColumnUp()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Up, RotationType.First));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateColumnDown()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Down, RotationType.First));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateLeft()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Left));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateRight()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Right));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateUp()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Up));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        public void RotateDown()
        {
            var movements = cube.Rotate(new Rotation(Rotation.Down));
            foreach (var facie in movements)
            {
                Rotate(facie);
            }
        }

        private void Rotate(IEnumerable<Face> facies)
        {
            var center = GetCenter(false);
            var negateCenter = GetCenter(true);

            foreach (var facie in facies)
            {
                var geometry = group.Children.FirstOrDefault(x => x.GetValue(NameProperty).ToString() == facie.Key);
                if (geometry != null)
                {
                    geometry.Transform = CreateTransformations(facie.Rotation, center, negateCenter);

                    //var matrixTransform = new MatrixTransform();
                    //geometry.RenderTransform = matrixTransform;

                    //var anim = new MatrixAnimationUsingKeyFrames();
                    //anim.KeyFrames = new MatrixKeyFrameCollection();
                    //anim.Duration = TimeSpan.FromSeconds(4);

                    //var fromMatrix = new Matrix(1, 0, 0, 1, 0, 0);
                    //var toMatrix = new Matrix(1, 0, 0, 1, 0, 0);

                    //anim.FillBehavior = FillBehavior.HoldEnd;
                    //var start = new DiscreteMatrixKeyFrame(fromMatrix, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
                    //var end = new DiscreteMatrixKeyFrame(toMatrix, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)));

                    //anim.KeyFrames.Add(start);
                    //anim.KeyFrames.Add(end);

                    //matrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, anim);
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

            //var matrixTransform = new MatrixTransform();
            //mainViewport.RenderTransform = matrixTransform;

            //var anim = new MatrixAnimationUsingKeyFrames();
            //anim.KeyFrames = new MatrixKeyFrameCollection();
            //anim.Duration = TimeSpan.FromSeconds(4);

            //var fromMatrix = new Matrix(1, 0, 0, 1, 0, 0);
            //var toMatrix = new Matrix(1, 0, 0, 1, 0, 0);

            //anim.FillBehavior = FillBehavior.HoldEnd;
            //var start = new DiscreteMatrixKeyFrame(fromMatrix, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
            //var end = new DiscreteMatrixKeyFrame(toMatrix, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)));

            //anim.KeyFrames.Add(start);
            //anim.KeyFrames.Add(end);

            //matrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, anim);

            //var cardAnimation = new DoubleAnimation();
            //cardAnimation.From = 0;
            //cardAnimation.To = 0.3;
            //cardAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            //cardAnimation.AutoReverse = true;

            //group.BeginAnimation(MatrixTransform3D.MatrixProperty, cardAnimation);
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

            //var binding = new Binding("Type2");
            //binding.Source = facie;
            //label.SetBinding(Label.ContentProperty, binding);

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

            geometry.SetValue(NameProperty, facie.Key);

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
    }
}