using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using RubiksCube.Core.Model;

namespace RubiksCube.UI
{
    public class FacieAnimation
    {
        private readonly IList<Tuple<Facie, Model3D>> animations;
        private readonly AutoResetEvent completeLock;
        private readonly Vector3D center;
        private readonly Vector3D negateCenter;
        private int nbComplete;

        public FacieAnimation(Vector3D center, Vector3D negateCenter)
        {
            this.center = center;
            this.negateCenter = negateCenter;

            animations = new List<Tuple<Facie, Model3D>>();
            completeLock = new AutoResetEvent(false);
        }

        public void Add(Facie facie, Model3D geometry)
        {
            animations.Add(new Tuple<Facie, Model3D>(facie, geometry));
        }

        public AutoResetEvent BeginAnimation()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate
            {
                foreach(var animation in animations)
                {
                    var previousMatrix3D = animation.Item1.PreviousRotation == null ? Matrix3D.Identity : MatrixMapper.Map(animation.Item1.PreviousRotation);
                    var newMatrix3D = MatrixMapper.Map(animation.Item1.Rotation);

                    var transformGroup = CreateTransformation(newMatrix3D);
                    animation.Item2.Transform = transformGroup;

                    var matrixAnimation = CreateAnimation(previousMatrix3D, newMatrix3D);
                    matrixAnimation.Completed += OnComplete;

                    var transform = transformGroup.Children[1];
                    transform.BeginAnimation(MatrixTransform3D.MatrixProperty, matrixAnimation);
                }
            });

            return completeLock;
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

        private void OnComplete(object sender, EventArgs args)
        {
            nbComplete++;
            if(nbComplete == animations.Count)
            {
                completeLock.Set();
            }
        }
    }
}