using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core
{
    public interface IRubiksCubeSolver
    {
        event EventHandler<UIRotation> Move;

        void Solve(Cube cube);
    }

    public class FriedrichSolver : IRubiksCubeSolver
    {
        public void Solve(Cube cube)
        {
            WhiteCross(cube);
        }

        public event EventHandler<UIRotation> Move;

        private void WhiteCross(Cube cube)
        {
            var edgeWhiteGreen = cube.GetEdge(Color.White, Color.Green);

            var strategy = new WhiteCrossMoveStrategy(edgeWhiteGreen.Item1, edgeWhiteGreen.Item2);
            foreach(var rotation in strategy.GetMovements(0))
            {
                OnMove(cube.Rotate(rotation));
            }
        }

        private void OnMove(UIRotation rotation)
        {
            var handler = Move;
            handler?.Invoke(this, rotation);
        }
    }

    internal static class CubeExtension
    {
        public static Tuple<FaceType, FaciePositionType> GetEdge(this Cube cube, Color color, Color adjacentColor)
        {
            foreach (var faceType in cube.FaceColors.Values)
            {
                var edges = cube[faceType].Facies.Where(x => x is Edge).Cast<Edge>();
                var edge = edges.FirstOrDefault(f => f.Color == color && f.AdjacentColor == adjacentColor);
                if (edge != null)
                {
                    return new Tuple<FaceType, FaciePositionType>(faceType, edge.Position);
                }
            }

            return null;
        }

        public static Tuple<FaceType, FaciePositionType> GetCorner(this Cube cube, Color color, Color adjacentColor1, Color adjacentColor2)
        {
            foreach (var faceType in cube.FaceColors.Values)
            {
                var corners = cube[faceType].Facies.Where(x => x is Corner).Cast<Corner>();
                var corner = corners.FirstOrDefault(f => f.Color == color && f.AdjacentColor1 == adjacentColor1 && f.AdjacentColor2 == adjacentColor2);
                if (corner != null)
                {
                    return new Tuple<FaceType, FaciePositionType>(faceType, corner.Position);
                }
            }

            return null;
        }
    }

    internal class WhiteCrossMoveStrategy
    {
        private FaceType item1;
        private FaciePositionType item2;

        public WhiteCrossMoveStrategy(FaceType item1, FaciePositionType item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public IEnumerable<RotationInfo> GetMovements(int i)
        {
            throw new NotImplementedException();
        }
    }
}