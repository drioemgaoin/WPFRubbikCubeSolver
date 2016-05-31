using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public interface IRubiksCubeSolver
    {
        void Solve(ICube cube);
    }
}