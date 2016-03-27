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
        public RotationsArgs(IEnumerable<FaceRotation> rotations)
        {
            Rotations = rotations;
        }

        public IEnumerable<FaceRotation> Rotations { get; private set; }
    }

    public class RubiksCubeSolver : IRubiksCubeSolver
    {
        public event EventHandler<RotationsArgs> Rotations;

        public void Solve(Cube cube)
        {
        }

        private void Notify(IEnumerable<FaceRotation> rotations)
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