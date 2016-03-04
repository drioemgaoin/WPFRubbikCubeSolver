namespace RubiksCube
{
    public static class MatrixHelper
    {
        public static double[,] Multiply(double[,] rotation1, double[,] rotation2)
        {
            var result = new double[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    result[i, j] = rotation1[i, 0] * rotation2[0, j] +
                                   rotation1[i, 1] * rotation2[1, j] +
                                   rotation1[i, 2] * rotation2[2, j] +
                                   rotation1[i, 3] * rotation2[3, j];
                }
            }

            return result;
        }

        public static double[,] Add(double[,] rotation1, double[,] rotation2)
        {
            var result = new double[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    result[i, j] = rotation1[i, j] + rotation2[i, j];
                }
            }

            return result;
        }
    }
}
