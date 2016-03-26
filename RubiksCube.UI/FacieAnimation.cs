using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace RubiksCube.UI
{
    public class FacieAnimation
    {
        private readonly IList<Tuple<Tuple<Matrix3D, Matrix3D>, Model3D>> animations;
        private readonly AutoResetEvent completeLock;
        private readonly Vector3D center;
        private readonly Vector3D negateCenter;

        public FacieAnimation(Vector3D center, Vector3D negateCenter)
        {
            this.center = center;
            this.negateCenter = negateCenter;

            animations = new List<Tuple<Tuple<Matrix3D, Matrix3D>, Model3D>>();
            completeLock = new AutoResetEvent(false);
        }

        public void Add(Matrix3D previousMatrix, Matrix3D matrix, Model3D geometry)
        {
            animations.Add(new Tuple<Tuple<Matrix3D, Matrix3D>, Model3D>(new Tuple<Matrix3D, Matrix3D>(previousMatrix, matrix), geometry));
        }

        public AutoResetEvent BeginAnimation()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate
            {
                foreach(var animation in animations)
                {
                    var previousMatrix3D = animation.Item1.Item1 == null ? Matrix3D.Identity : animation.Item1.Item1;
                    var newMatrix3D = animation.Item1.Item2;

                    var transformGroup = CreateTransformation(newMatrix3D);
                    animation.Item2.Transform = transformGroup;

                    var matrixAnimation = CreateAnimation(previousMatrix3D, newMatrix3D);
                    matrixAnimation.Completed += delegate { Notify(animation); };

                    var transform = transformGroup.Children[1];
                    transform.BeginAnimation(MatrixTransform3D.MatrixProperty, matrixAnimation);
                }
            });

            return completeLock;
        }

        private void Notify(Tuple<Tuple<Matrix3D, Matrix3D>, Model3D> animation)
        {
            animations.Remove(animation);

            if (animations.Count == 0)
            {
                completeLock.Set();
            }
        }

        private static Matrix3DAnimation CreateAnimation(Matrix3D previousMatrix3D, Matrix3D newMatrix3D)
        {
            var animationDuration = new Duration(new TimeSpan(0, 0, 0, 0, 100));
            return new Matrix3DAnimation(previousMatrix3D, newMatrix3D, animationDuration)
            {
                FillBehavior = FillBehavior.HoldEnd
            };
        }

        private Transform3DGroup CreateTransformation(Matrix3D newMatrix3D)
        {
            var transformGroup = new Transform3DGroup();
            var transform = new MatrixTransform3D(newMatrix3D);
            transformGroup.Children.Add(new TranslateTransform3D(negateCenter));
            transformGroup.Children.Add(transform);
            transformGroup.Children.Add(new TranslateTransform3D(center));
            return transformGroup;
        }
    }
}