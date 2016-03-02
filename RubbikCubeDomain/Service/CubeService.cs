using System;
using RubiksCube.Entity;

namespace RubiksCube.Service
{
    public interface ICubeService
    {
        double[,] RotateRowOnRightSide(Cube cube);
        double[,] RotateRowOnLeftSide(Cube cube);
        double[,] RotateRowOnUpSide(Cube cube);
        double[,] RotateRowOnDownSide(Cube cube);
    }

    public class CubeService : ICubeService
    {
        private readonly IRotationService rotationService;

        public CubeService()
        {
            rotationService = new RotationService();
        }

        public double[,] RotateRowOnRightSide(Cube cube)
        {
            var rotations = rotationService.RotationRow(Math.PI / 4);
            cube.Rotations = cube.Rotations == null ? rotations : Multiply(cube.Rotations, rotations);
            return cube.Rotations;
        }

        public double[,] RotateRowOnLeftSide(Cube cube)
        {
            var rotations = rotationService.RotationRow(-Math.PI / 4);
            cube.Rotations = cube.Rotations == null ? rotations : Multiply(cube.Rotations, rotations);
            return cube.Rotations;
        }

        public double[,] RotateRowOnUpSide(Cube cube)
        {
            var rotations = rotationService.RotationColumn(Math.PI / 4);
            cube.Rotations = cube.Rotations == null ? rotations : Multiply(cube.Rotations, rotations);
            return cube.Rotations;
        }

        public double[,] RotateRowOnDownSide(Cube cube)
        {
            var rotations = rotationService.RotationColumn(-Math.PI / 4);
            cube.Rotations = cube.Rotations == null ? rotations : Multiply(cube.Rotations, rotations);
            return cube.Rotations;
        }

        private static double[,] Multiply(double[,] rotation1, double[,] rotation2)
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
    }
}
