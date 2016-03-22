using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using RubiksCube.Core.Model;

namespace RubiksCube.UI
{
    public class MatrixAnimationWrapper
    {
        private readonly Face facie;
        private readonly Model3D geometry;
        private MatrixTransform3D transform;

        public MatrixAnimationWrapper(Face facie, Model3D geometry)
        {
            this.facie = facie;
            this.geometry = geometry;
        }

        public event EventHandler Complete;

        public bool IsComplete { get; private set; }

        public void BeginAnimation(Vector3D center, Vector3D negateCenter)
        {
            var previousMatrix3D = facie.PreviousRotation == null ? Matrix3D.Identity : MatrixMapper.Map(facie.PreviousRotation);
            var newMatrix3D = MatrixMapper.Map(facie.Rotation);

            geometry.Transform = CreateTransformation(newMatrix3D, center, negateCenter);

            var animation = CreateAnimation(previousMatrix3D, newMatrix3D);
            animation.Completed += OnComplete;

            transform.BeginAnimation(MatrixTransform3D.MatrixProperty, animation);
        }

        private static Matrix3DAnimation CreateAnimation(Matrix3D previousMatrix3D, Matrix3D newMatrix3D)
        {
            var animationDuration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            return new Matrix3DAnimation(previousMatrix3D, newMatrix3D, animationDuration)
            {
                FillBehavior = FillBehavior.HoldEnd
            };
        }

        private Transform3DGroup CreateTransformation(Matrix3D newMatrix3D, Vector3D center, Vector3D negateCenter)
        {
            var transformGroup = new Transform3DGroup();
            transform = new MatrixTransform3D(newMatrix3D);
            transformGroup.Children.Add(new TranslateTransform3D(negateCenter));
            transformGroup.Children.Add(transform);
            transformGroup.Children.Add(new TranslateTransform3D(center));
            return transformGroup;
        }

        private void OnComplete(object sender, EventArgs args)
        {
            IsComplete = true;
            Notify(args);
        }

        private void Notify(EventArgs args)
        {
            var handler = Complete;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}