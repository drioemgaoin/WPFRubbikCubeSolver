using System.Windows.Media;
using RubiksCube.Core.Model;
using Color = RubiksCube.Core.Model.Color;

namespace RubiksCube.UI
{
    public static class ColorMapper
    {
        public static System.Windows.Media.Color Map(Color color)
        {
            switch(color)
            {
                case Color.White:
                    return Colors.White;
                case Color.Blue:
                    return Colors.Blue;
                case Color.Green:
                    return Colors.Green;
                case Color.Orange:
                    return Colors.Orange;
                case Color.Red:
                    return Colors.Red;
                case Color.Yellow:
                    return Colors.Yellow;
            }

            return Colors.Transparent;
        }
    }
}
