using System;

namespace WpfApplication.Domain.Factory
{
    public interface IMatrixFactory
    {
        Func<double, double>[,] RotateZ();
        Func<double, double>[,] RotateX();
        Func<double, double>[,] RotateY();
    }

    public class MatrixFactory : IMatrixFactory
    {
        public Func<double, double>[,] RotateZ()
        {
            var matrix = new Func<double, double>[4, 4];
            matrix[0, 0] = angle => Math.Cos(angle);
            matrix[0, 1] = angle => Math.Sin(angle);
            matrix[0, 2] = angle => 0;
            matrix[0, 3] = angle => 0;
            matrix[1, 0] = angle => -Math.Sin(angle);
            matrix[1, 1] = angle => Math.Cos(angle);
            matrix[1, 2] = angle => 0;
            matrix[1, 3] = angle => 0;
            matrix[2, 0] = angle => 0;
            matrix[2, 1] = angle => 0;
            matrix[2, 2] = angle => 1;
            matrix[2, 3] = angle => 0;
            matrix[3, 0] = angle => 0;
            matrix[3, 1] = angle => 0;
            matrix[3, 2] = angle => 0;
            matrix[3, 3] = angle => 1;
            return matrix;
        }

        public Func<double, double>[,] RotateX()
        {
            var matrix = new Func<double, double>[4, 4];
            matrix[0, 0] = angle => 1;
            matrix[0, 1] = angle => 0;
            matrix[0, 2] = angle => 0;
            matrix[0, 3] = angle => 0;
            matrix[1, 0] = angle => 0;
            matrix[1, 1] = angle => Math.Cos(angle);
            matrix[1, 2] = angle => Math.Sin(angle);
            matrix[1, 3] = angle => 0;
            matrix[2, 0] = angle => 0;
            matrix[2, 1] = angle => -Math.Sin(angle);
            matrix[2, 2] = angle => Math.Cos(angle);
            matrix[2, 3] = angle => 0;
            matrix[3, 0] = angle => 0;
            matrix[3, 1] = angle => 0;
            matrix[3, 2] = angle => 0;
            matrix[3, 3] = angle => 1;
            return matrix;
        }

        public Func<double, double>[,] RotateY()
        {
            var matrix = new Func<double, double>[4, 4];
            matrix[0, 0] = angle => Math.Cos(2 * Math.PI - angle);
            matrix[0, 1] = angle => 0;
            matrix[0, 2] = angle => Math.Sin(2 * Math.PI - angle);
            matrix[0, 3] = angle => 0;
            matrix[1, 0] = angle => 0;
            matrix[1, 1] = angle => 1;
            matrix[1, 2] = angle => 0;
            matrix[1, 3] = angle => 0;
            matrix[2, 0] = angle => -Math.Sin(2 * Math.PI - angle);
            matrix[2, 1] = angle => 0;
            matrix[2, 2] = angle => Math.Cos(2 * Math.PI - angle);
            matrix[2, 3] = angle => 0;
            matrix[3, 0] = angle => 0;
            matrix[3, 1] = angle => 0;
            matrix[3, 2] = angle => 0;
            matrix[3, 3] = angle => 1;
            return matrix;
        }
    }
}
