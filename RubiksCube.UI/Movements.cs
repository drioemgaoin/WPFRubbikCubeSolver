using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;

namespace RubiksCube.UI
{
    public class Movements
    {
        private readonly IList<Movement> movements;
        private readonly Vector3D center;
        private readonly Vector3D negateCenter;

        public Movements(Vector3D center, Vector3D negateCenter)
        {
            this.center = center;
            this.negateCenter = negateCenter;

            movements = new List<Movement>();
        }

        public void Add(Movement movement)
        {
            movement.Complete += OnComplete;
            movements.Add(movement);
        }

        private void OnComplete(object sender, EventArgs e)
        {
            var movement = sender as Movement;
            if (movement != null)
            {
                movement.Complete -= OnComplete;

                var indexNextMovement = movements.IndexOf(movement) + 1;
                if (movements.Count > indexNextMovement)
                {
                    movements[indexNextMovement].BeginAnimation(center, negateCenter);
                }
            }
        }

        public void BeginAnimation()
        {
            movements.First().BeginAnimation(center, negateCenter);
        }
    }
}
