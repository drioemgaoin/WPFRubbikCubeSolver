using System;

namespace RubiksCube
{
    public static class MatrixHelper
    {
        public static double[,] Multiply(double[,] rotation1, double[,] rotation2)
        {
            var result = new double[4, 4];

            //M11 -> matrix1._m11 * matrix2._m11 + matrix1._m12 * matrix2._m21 + matrix1._m13 * matrix2._m31 + matrix1._m14 * matrix2._offsetX, 
            //M12 -> matrix1._m11 * matrix2._m12 + matrix1._m12 * matrix2._m22 + matrix1._m13 * matrix2._m32 + matrix1._m14 * matrix2._offsetY, 
            //M13 -> matrix1._m11 * matrix2._m13 + matrix1._m12 * matrix2._m23 + matrix1._m13 * matrix2._m33 + matrix1._m14 * matrix2._offsetZ, 
            //M14 -> matrix1._m11 * matrix2._m14 + matrix1._m12 * matrix2._m24 + matrix1._m13 * matrix2._m34 + matrix1._m14 * matrix2._m44, 
            result[0, 0] = rotation1[0, 0] * rotation2[0, 0] + 
                           rotation1[0, 1] * rotation2[1, 0] +
                           rotation1[0, 2] * rotation2[2, 0] + 
                           rotation1[3, 0] * rotation2[0, 3];

            result[0, 1] = rotation1[0, 0] * rotation2[0, 1] +
                           rotation1[0, 1] * rotation2[1, 1] +
                           rotation1[0, 2] * rotation2[2, 1] +
                           rotation1[3, 0] * rotation2[1, 3];

            result[0, 2] = rotation1[0, 0] * rotation2[0, 2] +
                           rotation1[0, 1] * rotation2[1, 2] +
                           rotation1[0, 2] * rotation2[2, 2] +
                           rotation1[3, 0] * rotation2[2, 3];

            result[3, 0] = rotation1[0, 0] * rotation2[3, 0] +
                           rotation1[0, 1] * rotation2[3, 1] +
                           rotation1[0, 2] * rotation2[3, 2] +
                           rotation1[3, 0] * rotation2[3, 3];


            //M21 -> matrix1._m21 * matrix2._m11 + matrix1._m22 * matrix2._m21 + matrix1._m23 * matrix2._m31 + matrix1._m24 * matrix2._offsetX, 
            //M22 -> matrix1._m21 * matrix2._m12 + matrix1._m22 * matrix2._m22 + matrix1._m23 * matrix2._m32 + matrix1._m24 * matrix2._offsetY, 
            //M23 -> matrix1._m21 * matrix2._m13 + matrix1._m22 * matrix2._m23 + matrix1._m23 * matrix2._m33 + matrix1._m24 * matrix2._offsetZ, 
            //M24 -> matrix1._m21 * matrix2._m14 + matrix1._m22 * matrix2._m24 + matrix1._m23 * matrix2._m34 + matrix1._m24 * matrix2._m44, 
            result[1, 0] = rotation1[1, 0] * rotation2[0, 0] +
                           rotation1[1, 1] * rotation2[1, 0] +
                           rotation1[1, 2] * rotation2[2, 0] +
                           rotation1[3, 1] * rotation2[0, 3];

            result[1, 1] = rotation1[1, 0] * rotation2[0, 1] +
                           rotation1[1, 1] * rotation2[1, 1] +
                           rotation1[1, 2] * rotation2[2, 1] +
                           rotation1[3, 1] * rotation2[1, 3];

            result[1, 2] = rotation1[1, 0] * rotation2[0, 2] +
                           rotation1[1, 1] * rotation2[1, 2] +
                           rotation1[1, 2] * rotation2[2, 2] +
                           rotation1[3, 1] * rotation2[2, 3];

            result[3, 1] = rotation1[1, 0] * rotation2[3, 0] +
                           rotation1[1, 1] * rotation2[3, 1] +
                           rotation1[1, 2] * rotation2[3, 2] +
                           rotation1[3, 1] * rotation2[3, 3];



            //M31 -> matrix1._m31 * matrix2._m11 + matrix1._m32 * matrix2._m21 + matrix1._m33 * matrix2._m31 + matrix1._m34 * matrix2._offsetX, 
            //M32 -> matrix1._m31 * matrix2._m12 + matrix1._m32 * matrix2._m22 + matrix1._m33 * matrix2._m32 + matrix1._m34 * matrix2._offsetY, 
            //M33 -> matrix1._m31 * matrix2._m13 + matrix1._m32 * matrix2._m23 + matrix1._m33 * matrix2._m33 + matrix1._m34 * matrix2._offsetZ, 
            //M34 -> matrix1._m31 * matrix2._m14 + matrix1._m32 * matrix2._m24 + matrix1._m33 * matrix2._m34 + matrix1._m34 * matrix2._m44, 
            result[2, 0] = rotation1[2, 0] * rotation2[0, 0] +
                           rotation1[2, 1] * rotation2[1, 0] +
                           rotation1[2, 2] * rotation2[2, 0] +
                           rotation1[3, 2] * rotation2[0, 3];

            result[2, 1] = rotation1[2, 0] * rotation2[0, 1] +
                           rotation1[2, 1] * rotation2[1, 1] +
                           rotation1[2, 2] * rotation2[2, 1] +
                           rotation1[3, 2] * rotation2[1, 3];

            result[2, 2] = rotation1[2, 0] * rotation2[0, 2] +
                           rotation1[2, 1] * rotation2[1, 2] +
                           rotation1[2, 2] * rotation2[2, 2] +
                           rotation1[3, 2] * rotation2[2, 3];

            result[3, 2] = rotation1[2, 0] * rotation2[3, 0] +
                           rotation1[2, 1] * rotation2[3, 1] +
                           rotation1[2, 2] * rotation2[3, 2] +
                           rotation1[3, 2] * rotation2[3, 3];


            //offsetX -> matrix1._offsetX * matrix2._m11 + matrix1._offsetY * matrix2._m21 + matrix1._offsetZ * matrix2._m31 + matrix1._m44 * matrix2._offsetX, 
            //offsetY -> matrix1._offsetX * matrix2._m12 + matrix1._offsetY * matrix2._m22 + matrix1._offsetZ * matrix2._m32 + matrix1._m44 * matrix2._offsetY, 
            //offsetZ -> matrix1._offsetX * matrix2._m13 + matrix1._offsetY * matrix2._m23 + matrix1._offsetZ * matrix2._m33 + matrix1._m44 * matrix2._offsetZ, 
            //M44 -> matrix1._offsetX * matrix2._m14 + matrix1._offsetY * matrix2._m24 + matrix1._offsetZ * matrix2._m34 + matrix1._m44 * matrix2._m44
            result[0, 3] = rotation1[0, 3] * rotation2[0, 0] +
                           rotation1[1, 3] * rotation2[1, 0] +
                           rotation1[2, 3] * rotation2[2, 0] +
                           rotation1[3, 3] * rotation2[0, 3];

            result[1, 3] = rotation1[0, 3] * rotation2[0, 1] +
                           rotation1[1, 3] * rotation2[1, 1] +
                           rotation1[2, 3] * rotation2[2, 1] +
                           rotation1[3, 3] * rotation2[1, 3];

            result[2, 3] = rotation1[0, 3] * rotation2[0, 2] +
                           rotation1[1, 3] * rotation2[1, 2] +
                           rotation1[2, 3] * rotation2[2, 2] +
                           rotation1[3, 3] * rotation2[2, 3];

            result[3, 3] = rotation1[0, 3] * rotation2[3, 0] +
                           rotation1[1, 3] * rotation2[3, 1] +
                           rotation1[2, 3] * rotation2[3, 2] +
                           rotation1[3, 3] * rotation2[3, 3];

            //for (var i = 0; i < 4; i++)
            //{
            //    for (var j = 0; j < 4; j++)
            //    {
            //        result[i, j] = rotation1[i, 0] * rotation2[0, j] +
            //                       rotation1[i, 1] * rotation2[1, j] +
            //                       rotation1[i, 2] * rotation2[2, j] +
            //                       rotation1[i, 3] * rotation2[3, j];
            //        result[i, j] = Math.Round(result[i, j], 0);
            //    }
            //}


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
