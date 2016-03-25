using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public interface IRubiksCubeSolver
    {
        event EventHandler<RotationsArgs> Rotations;

        void Solve(Cube cube);
    }

    public class RotationsArgs : EventArgs
    {
        public RotationsArgs(IEnumerable<Rotation> rotations)
        {
            Rotations = rotations;
        }

        public IEnumerable<Rotation> Rotations { get; private set; }
    }

    public class RubiksCubeSolver : IRubiksCubeSolver
    {
        public event EventHandler<RotationsArgs> Rotations;

        public void Solve(Cube cube)
        {
            PositionToWhiteFace(cube);
            //PositionTopMiddleWiteFace(cube);
        }

        private void PositionTopMiddleWiteFace(Cube cube)
        {
            var rotations = new List<Rotation>();
            var face = cube.Find(Color.White, FaciePositionType.MiddleTop);
            if (face != null)
            {
                if (face.Type == FaceType.Left)
                {
                    rotations.Add(new Rotation(Rotation.Right, 1, RotationType.First));
                }
                else if (face.Type == FaceType.Right)
                {
                    rotations.Add(new Rotation(Rotation.Left, 1, RotationType.First));
                }
                else if (face.Type == FaceType.Back)
                {
                    rotations.Add(new Rotation(Rotation.Left, 2, RotationType.First));
                }
                else if (face.Type == FaceType.Top)
                {
                    if (face.Facies.Any(x => x.FaciePosition == FaciePositionType.MiddleTop && x.Color == Color.White))
                    {
                        rotations.Add(new Rotation(Rotation.Left, 1, RotationType.Second));
                        rotations.Add(new Rotation(Rotation.Down, 1, RotationType.Second));
                        rotations.Add(new Rotation(Rotation.Right, 1, RotationType.Second));
                    }
                    else if (face.Facies.Any(x => x.FaciePosition == FaciePositionType.MiddleBottom && x.Color == Color.White))
                    {
                        rotations.Add(new Rotation(Rotation.Left, 2, RotationType.First));
                        rotations.Add(new Rotation(Rotation.Left, 1, RotationType.Second));
                        rotations.Add(new Rotation(Rotation.Down, 1, RotationType.Second));
                        rotations.Add(new Rotation(Rotation.Right, 1, RotationType.Second));
                    }
                }
            }

            Notify(rotations);
        }

        private void PositionToWhiteFace(Cube cube)
        {
            var whiteFace = cube.Find(Color.White);
            if (whiteFace != null)
            {
                switch (whiteFace.Type)
                {
                    case FaceType.Back:
                        Notify(new[] { new Rotation(Rotation.Left, 2) });
                        break;
                    case FaceType.Left:
                        Notify(new[] { new Rotation(Rotation.Right, 1) });
                        break;
                    case FaceType.Right:
                        Notify(new[] { new Rotation(Rotation.Left, 1) });
                        break;
                    case FaceType.Top:
                        Notify(new[] { new Rotation(Rotation.Down, 1) });
                        break;
                    case FaceType.Bottom:
                        Notify(new[] { new Rotation(Rotation.Up, 1) });
                        break;
                }
            }
        }

        private void Notify(IEnumerable<Rotation> rotations)
        {
            var handler = Rotations;
            if (handler != null)
            {
                var args = new RotationsArgs(rotations);
                handler(this, args);
            }
        }
    }
}