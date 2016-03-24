using System.Windows.Media;
using RubiksCube.Core.Model;

namespace RubiksCube.UI
{
    public static class ColorMapper
    {
        public static Color Map(ColorName colorName)
        {
            switch(colorName)
            {
                case ColorName.White:
                    return Colors.White;
                case ColorName.Blue:
                    return Colors.Blue;
                case ColorName.Green:
                    return Colors.Green;
                case ColorName.Orange:
                    return Colors.Orange;
                case ColorName.Red:
                    return Colors.Red;
                case ColorName.Yellow:
                    return Colors.Yellow;
            }

            return Colors.Transparent;
        }
    }
}
