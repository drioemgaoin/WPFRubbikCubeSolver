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

            var rotations = new List<Rotation>();
            var facies = cube.LeftFace.Facies.Where(x => x.Color == Color.White).ToArray();
            foreach (var facie in facies)
            {
                if (facie.FaciePosition == FaciePositionType.LeftTop ||
                    facie.FaciePosition == FaciePositionType.MiddleTop ||
                    facie.FaciePosition == FaciePositionType.RightTop)
                {
                    rotations.Add(new Rotation(Rotation.Right, 1, RotationType.First));
                }

                if (facie.FaciePosition == FaciePositionType.LeftBottom ||
                    facie.FaciePosition == FaciePositionType.MiddleBottom ||
                    facie.FaciePosition == FaciePositionType.RightBottom)
                {
                    rotations.Add(new Rotation(Rotation.Right, 1, RotationType.Third));
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