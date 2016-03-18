using RubiksCube.Enums;

namespace RubiksCube
{
    public class Rotation
    {
        public const string Up = "Up";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Down = "Down";

        private static readonly string[] Directions = {Up, Left, Right, Down};

        public Rotation(string direction)
            : this(direction, 1, RotationType.All)
        {

        }

        public Rotation(string direction, uint times)
            : this(direction, times, RotationType.All)
        {
            
        }

        public Rotation(string direction, uint times, RotationType type)
        {
            Guard.IsNotNullOrWhitespace(direction, "direction");
            Guard.Contains(Directions, direction, string.Format("'{0}' is not a valid face rotation direction.", direction));

            Direction = direction;
            Times = times;
            Type = type;
        }

        public string Direction { get; private set; }

        public uint Times { get; private set; }

        public RotationType Type { get; private set; }
    }
}
