using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model;

namespace RubiksCube.Core
{
    public class FriedrichSolver : IRubiksCubeSolver
    {
        private class EdgePosition : Tuple<FaceType, Color, Color, FaciePositionType>
        {
            public EdgePosition(FaceType faceType, Color facieColor, Color adjacentColor, FaciePositionType faciePosition) 
                : base(faceType, facieColor, adjacentColor, faciePosition)
            {
            }
        }

        public void Solve(Cube cube)
        {
            WhiteCross(cube);
        }

        public event EventHandler<UIRotation> Moving;

        private void WhiteCross(Cube cube)
        {
            var algorythms = new Dictionary<EdgePosition, string>();
            algorythms.Add(new EdgePosition(FaceType.Left, Color.White, Color.Red, FaciePositionType.MiddleDown), "D");
            algorythms.Add(new EdgePosition(FaceType.Back, Color.White, Color.Blue, FaciePositionType.RightMiddle), "R2");
            algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Orange, FaciePositionType.MiddleUp), "U2 U' F R' F'");
            algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Orange, FaciePositionType.MiddleDown), "U' F R' F'");
            algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Green, FaciePositionType.MiddleUp), "B L2' L' X X L");

            var edgePositions = GetEdgePositions(cube, Color.White, new []{FaceType.Back, FaceType.Down, FaceType.Left, FaceType.Right, FaceType.Up});
            foreach (var edgePosition in edgePositions)
            {
                if (!algorythms.ContainsKey(edgePosition))
                {
                    continue; 
                }

                var algorythm = algorythms[edgePosition];
                var rotations = MoveInterpretor.Interpret(algorythm);
                foreach (var rotation in rotations)
                {
                    OnMoving(cube.Rotate(rotation));
                }
            }
        }

        private static IEnumerable<EdgePosition> GetEdgePositions(Cube cube, Color color, FaceType[] faces)
        {
            var positions = new List<EdgePosition>();

            foreach (var face in faces)
            {
                var facePositions = cube[face].Facies
                    .Where(facie => facie.Color == color && facie is Edge).Cast<Edge>()
                    .Select(edge => new EdgePosition(face, color, edge.AdjacentColor, edge.Position));

                positions.AddRange(facePositions);
            }

            return positions;
        }


        private void OnMoving(UIRotation rotation)
        {
            var handler = Moving;
            handler?.Invoke(this, rotation);
        }
    }
}