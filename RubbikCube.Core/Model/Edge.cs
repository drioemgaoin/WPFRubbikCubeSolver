namespace RubiksCube.Core.Model
{
    public class Edge : Facie
    {
        public Edge(FaciePositionType position, Color color, Color adjacentColor) : base(color, position)
        {
            AdjacentColor = adjacentColor;
        }

        public Color AdjacentColor { get; }
    }
}
