using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using RubiksCube.Core.Model;

namespace RubiksCube.UI
{
    public class Movement
    {
        private readonly ICollection<MatrixAnimationWrapper> animations;

        public Movement()
        {
            animations = new List<MatrixAnimationWrapper>();
        }

        public event EventHandler Complete;

        public void CreateAnimation(Face facie, Model3D geometry)
        {
            var animation = new MatrixAnimationWrapper(facie, geometry);
            animations.Add(animation);
        }

        public void BeginAnimation(Vector3D center, Vector3D negateCenter)
        {
            foreach (var animation in animations)
            {
                animation.Complete += OnComplete;
                animation.BeginAnimation(center, negateCenter);
            }
        }

        private void OnComplete(object sender, EventArgs args)
        {
            var animation = sender as MatrixAnimationWrapper;
            if (animation != null)
            {
                animation.Complete -= OnComplete;
            }

            if (animations.All(x => x.IsComplete))
            {
                var handler = Complete;
                if (handler != null)
                {
                    handler(this, args);
                }
            }
        }
    }
}
