namespace RubiksCube.Core.Model
{
    internal class Edge : Facie
    {
        public Edge(FaciePositionType position, Color color, Color adjacentColor) : base(color, position)
        {
            AdjacentColor = adjacentColor;
        }

        public Color AdjacentColor { get; }
    }
}
