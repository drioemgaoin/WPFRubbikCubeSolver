using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;

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