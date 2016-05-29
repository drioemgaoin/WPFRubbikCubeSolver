using System;
using RubiksCube.Core.Model;

namespace RubiksCube.Solvers
{
    public class EdgePosition : Tuple<FaceType, Color, Color, FaciePositionType>
    {
        public EdgePosition(FaceType faceType, Color facieColor, Color adjacentColor, FaciePositionType faciePosition)
            : base(faceType, facieColor, adjacentColor, faciePosition)
        {
        }
    }
}
