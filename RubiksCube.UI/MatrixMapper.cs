using System.Windows.Media.Media3D;

namespace RubiksCube.UI
{
    public static class MatrixMapper
    {
        public static Matrix3D Map(double[,] matrix)
        {
            var matrix3D = new Matrix3D();
            matrix3D.M11 = matrix[0, 0];
            matrix3D.M12 = matrix[0, 1];
            matrix3D.M13 = matrix[0, 2];
            matrix3D.M21 = matrix[1, 0];
            matrix3D.M22 = matrix[1, 1];
            matrix3D.M23 = matrix[1, 2];
            matrix3D.M31 = matrix[2, 0];
            matrix3D.M32 = matrix[2, 1];
            matrix3D.M33 = matrix[2, 2];

            matrix3D.M14 = matrix[3, 0];
            matrix3D.M24 = matrix[3, 1];
            matrix3D.M34 = matrix[3, 2];

            matrix3D.OffsetX = matrix[0, 3];
            matrix3D.OffsetY = matrix[1, 3];
            matrix3D.OffsetZ = matrix[2, 3];

            matrix3D.M44 = matrix[3, 3];

            return matrix3D;
        }
    }
}
