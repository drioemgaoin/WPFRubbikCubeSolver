using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model;

namespace RubiksCube.Solvers
{
    public static class CubeExtensions
    {
        public static IEnumerable<EdgePosition> GetEdgePositions(this ICube cube, Color color, FaceType[] faces)
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
    }
}
