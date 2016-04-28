using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public interface IRubiksCubeSolver
    {
        void Solve(Cube cube);
    }

    public class RubiksCubeSolver : IRubiksCubeSolver
    {
        public void Solve(Cube cube)
        {
            //cube
        }
    }
}