namespace RubiksCube.Core.Model
{
    internal class Corner : Facie
    {
        public Corner(FaciePositionType position, Color color, Color adjacentColor1, Color adjacentColor2) : base(color, position)
        {
            AdjacentColor1 = adjacentColor1;
            AdjacentColor2 = adjacentColor2;
        }

        public Color AdjacentColor1 { get; }

        public Color AdjacentColor2 { get; }
    }
}
