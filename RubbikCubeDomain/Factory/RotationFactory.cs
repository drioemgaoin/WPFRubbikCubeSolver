using System;

namespace RubiksCube.Factory
{
    public interface IRotationFactory
    {
        Func<double>[,] RotateX(double angle);
        Func<double>[,] RotateY(double angle);
        Func<double>[,] RotateZ(double angle);
    }

    public class RotationFactory : IRotationFactory
    {
        public Func<double>[,] RotateX(double angle)
        {
            var matrix = new Func<double>[4, 4];
            matrix[0, 0] = () => 1;
            matrix[0, 1] = () => 0;
            matrix[0, 2] = () => 0;
            matrix[0, 3] = () => 0;
            matrix[1, 0] = () => 0;
            matrix[1, 1] = () => Math.Cos(angle);
            matrix[1, 2] = () => Math.Sin(angle);
            matrix[1, 3] = () => 0;
            matrix[2, 0] = () => 0;
            matrix[2, 1] = () => -Math.Sin(angle);
            matrix[2, 2] = () => Math.Cos(angle);
            matrix[2, 3] = () => 0;
            matrix[3, 0] = () => 0;
            matrix[3, 1] = () => 0;
            matrix[3, 2] = () => 0;
            matrix[3, 3] = () => 1;
            return matrix;
        }

        public Func<double>[,] RotateY(double angle)
        {
            var matrix = new Func<double>[4, 4];
            matrix[0, 0] = () => Math.Cos(2 * Math.PI - angle);
            matrix[0, 1] = () => 0;
            matrix[0, 2] = () => Math.Sin(2 * Math.PI - angle);
            matrix[0, 3] = () => 0;
            matrix[1, 0] = () => 0;
            matrix[1, 1] = () => 1;
            matrix[1, 2] = () => 0;
            matrix[1, 3] = () => 0;
            matrix[2, 0] = () => -Math.Sin(2 * Math.PI - angle);
            matrix[2, 1] = () => 0;
            matrix[2, 2] = () => Math.Cos(2 * Math.PI - angle);
            matrix[2, 3] = () => 0;
            matrix[3, 0] = () => 0;
            matrix[3, 1] = () => 0;
            matrix[3, 2] = () => 0;
            matrix[3, 3] = () => 1;
            return matrix;
        }

        public Func<double>[,] RotateZ(double angle)
        {
            var matrix = new Func<double>[4, 4];
            matrix[0, 0] = () => Math.Cos(angle);
            matrix[0, 1] = () => Math.Sin(angle);
            matrix[0, 2] = () => 0;
            matrix[0, 3] = () => 0;
            matrix[1, 0] = () => -Math.Sin(angle);
            matrix[1, 1] = () => Math.Cos(angle);
            matrix[1, 2] = () => 0;
            matrix[1, 3] = () => 0;
            matrix[2, 0] = () => 0;
            matrix[2, 1] = () => 0;
            matrix[2, 2] = () => 1;
            matrix[2, 3] = () => 0;
            matrix[3, 0] = () => 0;
            matrix[3, 1] = () => 0;
            matrix[3, 2] = () => 0;
            matrix[3, 3] = () => 1;
            return matrix;
        }
    }
}