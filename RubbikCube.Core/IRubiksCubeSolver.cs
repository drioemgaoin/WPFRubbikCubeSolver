using System;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public interface IRubiksCubeSolver
    {
        event EventHandler<UIRotation> Moving;

        void Solve(Cube cube);
    }
}