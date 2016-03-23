using System;

namespace RubiksCube.Core.Model
{
    public class Rotation
    {
        public const string Up = "Up";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Down = "Down";

        private static readonly string[] Directions = {Up, Left, Right, Down};
        private double angle;
        private double cumulativeRotation;

        public Rotation(string direction, uint times)
            : this(direction, Math.PI / 2, times, RotationType.All)
        {
            
        }

        public Rotation(string direction, double angle)
            : this(direction, angle, (uint)((Math.PI / 2) / angle), RotationType.All)
        {

        }

        public Rotation(string direction, uint times, RotationType type)
            : this(direction, Math.PI / 2, times, type)
        {
        }

        public Rotation(string direction, double angle, RotationType type)
            : this(direction, angle, (uint)((Math.PI / 2) / angle), type)
        {
        }

        public Rotation(string direction, double angle, uint times, RotationType type)
        {
            Guard.IsNotNullOrWhitespace(direction, "direction");
            Guard.Contains(Directions, direction, String.Format("'{0}' is not a valid face rotation direction.", direction));

            this.angle = angle;
            Direction = direction;
            Times = times;
            Type = type;
        }

        public bool IsMatchFace
        {
            get { return Math.Abs(cumulativeRotation) % (Math.PI / 2) == 0; }
        }

        public double Angle
        {
            get
            {
                cumulativeRotation += angle;
                return angle;
            }
        }

        public string Direction { get; private set; }

        public uint Times { get; private set; }

        public RotationType Type { get; private set; }
    }
}
