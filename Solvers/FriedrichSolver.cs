using RubiksCube.Core;
using RubiksCube.Core.Model;

namespace RubiksCube.Solvers
{
    public partial class FriedrichSolver : IRubiksCubeSolver
    {
        private readonly WhiteCross whiteCross;

        public FriedrichSolver()
        {
            whiteCross = new WhiteCross();
        }

        public void Solve(ICube cube)
        {
            whiteCross.Solve(cube);
        }
    }
}