using System;
using System.Collections.Generic;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core.Model
{
    public class UIRotation
    {
        private const double HalfRotationAngle = Math.PI / 4;

        internal UIRotation(Rotation rotation)
        {
            Matrix = rotation.CreateMatrix(rotation.Angle > 0 ? HalfRotationAngle : -HalfRotationAngle);
            Moves = rotation.Facies;
        }
            
        public IList<List<Facie>> Moves { get; }

        public double[,] Matrix { get; }
    }
}
