using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core
{
    internal static class CubeExtension
    {
        //public static Tuple<FaceType, FaciePositionType> GetEdge(this Cube cube, Color color, Color adjacentColor)
        //{
        //    foreach (var faceType in cube.FaceColors.Values)
        //    {
        //        var edges = cube[faceType].Facies.Where(x => x is Edge).Cast<Edge>();
        //        var edge = edges.FirstOrDefault(f => f.Color == color && f.AdjacentColor == adjacentColor);
        //        if (edge != null)
        //        {
        //            return new Tuple<FaceType, FaciePositionType>(faceType, edge.Position);
        //        }
        //    }

        //    return null;
        //}

        //public static Tuple<FaceType, FaciePositionType> GetCorner(this Cube cube, Color color, Color adjacentColor1, Color adjacentColor2)
        //{
        //    foreach (var faceType in cube.FaceColors.Values)
        //    {
        //        var corners = cube[faceType].Facies.Where(x => x is Corner).Cast<Corner>();
        //        var corner = corners.FirstOrDefault(f => f.Color == color && f.AdjacentColor1 == adjacentColor1 && f.AdjacentColor2 == adjacentColor2);
        //        if (corner != null)
        //        {
        //            return new Tuple<FaceType, FaciePositionType>(faceType, corner.Position);
        //        }
        //    }

        //    return null;
        //}
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