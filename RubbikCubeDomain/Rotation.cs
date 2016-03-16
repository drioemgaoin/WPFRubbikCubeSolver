namespace RubiksCube
{
    public class Rotation
    {
        public const string Up = "Up";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Down = "Down";

        private static readonly string[] Directions = {Up, Left, Right, Down};

        public Rotation(string direction, uint times)
        {
            Guard.IsNotNullOrWhitespace(direction, "direction");
            Guard.Contains(Directions, direction, string.Format("'{0}' is not a valid face rotation direction.", direction));

            Direction = direction;
            Times = times;
        }

        public string Direction { get; private set; }

        public uint Times { get; private set; }
    }
}
