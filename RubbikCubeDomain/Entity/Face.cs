using System.Collections.Generic;
using System.Windows.Media;
using RubiksCube.Enums;

namespace RubiksCube.Entity
{
    public class Face
    {
        public Face()
        {
            Facies = new List<Face>();
        }

        public double[,] Rotation { get; set; }

        public FaceType Type { get; set; }

        public FaciePositionType FaciePositionType { get; set; }

        public Color Color { get; set; }

        public IList<Face> Facies { get; set; }
    }
}