using System.Collections.Generic;
using RubiksCube.Core;
using RubiksCube.Core.Model;

namespace RubiksCube.Solvers
{
    public partial class FriedrichSolver
    {
        private class WhiteCross
        {
            private readonly IDictionary<EdgePosition, string> algorythms;

            public WhiteCross()
            {
                algorythms = new Dictionary<EdgePosition, string>();
                algorythms.Add(new EdgePosition(FaceType.Left, Color.White, Color.Red, FaciePositionType.MiddleDown), "D");
                algorythms.Add(new EdgePosition(FaceType.Left, Color.White, Color.Orange, FaciePositionType.MiddleUp), "U'");
                algorythms.Add(new EdgePosition(FaceType.Left, Color.White, Color.Green, FaciePositionType.RightMiddle), "L F' D F");

                algorythms.Add(new EdgePosition(FaceType.Right, Color.White, Color.Orange, FaciePositionType.MiddleUp), "U");
                algorythms.Add(new EdgePosition(FaceType.Right, Color.White, Color.Red, FaciePositionType.MiddleDown), "D'");
                algorythms.Add(new EdgePosition(FaceType.Right, Color.White, Color.Blue, FaciePositionType.LeftMiddle), "R F' U F");

                algorythms.Add(new EdgePosition(FaceType.Back, Color.White, Color.Blue, FaciePositionType.RightMiddle), "R2");
                algorythms.Add(new EdgePosition(FaceType.Back, Color.White, Color.Orange, FaciePositionType.MiddleUp), "U2");

                algorythms.Add(new EdgePosition(FaceType.Down, Color.White, Color.Green, FaciePositionType.RightMiddle), "L'");
                algorythms.Add(new EdgePosition(FaceType.Down, Color.White, Color.Blue, FaciePositionType.LeftMiddle), "R");

                algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Green, FaciePositionType.LeftMiddle), "L");
                algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Blue, FaciePositionType.RightMiddle), "R'");
                algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Orange, FaciePositionType.MiddleDown), "U' F R' F'");
                algorythms.Add(new EdgePosition(FaceType.Up, Color.White, Color.Orange, FaciePositionType.MiddleUp), "U F R' F'");
            }

            public void Solve(ICube cube)
            {
                var edgePositions = cube.GetEdgePositions(Color.White, new[] { FaceType.Back, FaceType.Down, FaceType.Left, FaceType.Right, FaceType.Up });
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
                        cube.Rotate(rotation);
                    }
                }
            }
        }
    }
}
