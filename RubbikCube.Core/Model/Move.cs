namespace RubiksCube.Core.Model
{
    public static class Move
    {
        public class Face
        {
            public const string Up = "Up";
            public const string Right = "Right";
            public const string Down = "Down";
            public const string Left = "Left";
        }

        public class Layer
        {
            public const string Clockwise = "Clockwise";
            public const string CounterClockwise = "CounterClockwise";
        }
    }
}
