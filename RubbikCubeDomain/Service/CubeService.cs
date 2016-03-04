using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Entity;
using RubiksCube.Enums;

namespace RubiksCube.Service
{
    public interface ICubeService
    {
        IList<Face> RotateRowOnRightSide(Cube cube, int indexRow);
        IList<Face> RotateRowOnLeftSide(Cube cube, int indexRow);
        IList<Face> RotateColumnOnUpSide(Cube cube, int indexColumn);
        IList<Face> RotateColumnOnDownSide(Cube cube, int indexColumn);

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

        public IList<Face> RotateRowOnRightSide(Cube cube, int indexRow)
        {
            var angle = Math.PI/4;

            var facies = new List<Face>();
            facies.AddRange(RotateFirstRow(cube.FrontFace, angle));
            facies.AddRange(RotateFirstRow(cube.RightFace, angle));
            facies.AddRange(RotateFirstRow(cube.BackFace, angle));
            facies.AddRange(RotateFirstRow(cube.LeftFace, angle));
            return facies;
        }

        public IList<Face> RotateRowOnLeftSide(Cube cube, int indexRow)
        {
            var angle = -Math.PI / 4;

            var facies = new List<Face>();
            facies.AddRange(RotateFirstRow(cube.FrontFace, angle));
            facies.AddRange(RotateFirstRow(cube.RightFace, angle));
            facies.AddRange(RotateFirstRow(cube.BackFace, angle));
            facies.AddRange(RotateFirstRow(cube.LeftFace, angle));
            return facies;
        }

        public IList<Face> RotateColumnOnUpSide(Cube cube, int indexColumn)
        {
            var angle = Math.PI / 4;

            var facies = new List<Face>();
            facies.AddRange(RotateFirstColumn(cube.FrontFace, angle));
            facies.AddRange(RotateFirstColumn(cube.TopFace, angle));
            facies.AddRange(RotateFirstColumn(cube.BackFace, angle));
            facies.AddRange(RotateFirstColumn(cube.BottomFace, angle));
            return facies;
        }

        public IList<Face> RotateColumnOnDownSide(Cube cube, int indexColumn)
        {
            var angle = -Math.PI / 4;

            var facies = new List<Face>();
            facies.AddRange(RotateFirstColumn(cube.FrontFace, angle));
            facies.AddRange(RotateFirstColumn(cube.TopFace, angle));
            facies.AddRange(RotateFirstColumn(cube.BackFace, angle));
            facies.AddRange(RotateFirstColumn(cube.BottomFace, angle));
            return facies;
        }

        public double[,] RotateRowOnRightSide(Cube cube)
        {
            var matrix = rotationService.RotationRow(Math.PI / 4);
            cube.Matrix = cube.Matrix == null ? matrix : MatrixHelper.Multiply(cube.Matrix, matrix);
            return cube.Matrix;
        }

        public double[,] RotateRowOnLeftSide(Cube cube)
        {
            var rotations = rotationService.RotationRow(-Math.PI / 4);
            cube.Matrix = cube.Matrix == null ? rotations : MatrixHelper.Multiply(cube.Matrix, rotations);
            return cube.Matrix;
        }

        public double[,] RotateRowOnUpSide(Cube cube)
        {
            var rotations = rotationService.RotationColumn(Math.PI / 4);
            cube.Matrix = cube.Matrix == null ? rotations : MatrixHelper.Multiply(cube.Matrix, rotations);
            return cube.Matrix;
        }

        public double[,] RotateRowOnDownSide(Cube cube)
        {
            var rotations = rotationService.RotationColumn(-Math.PI / 4);
            cube.Matrix = cube.Matrix == null ? rotations : MatrixHelper.Multiply(cube.Matrix, rotations);
            return cube.Matrix;
        }

        private IEnumerable<Face> RotateFirstRow(Face face, double angle)
        {
            var rotation = rotationService.RotationRow(angle);
            
            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.LeftTop ||
                x.FaciePositionType == FaciePositionType.MiddleTop ||
                x.FaciePositionType == FaciePositionType.RightTop);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }

        private IEnumerable<Face> RotateFirstColumn(Face face, double angle)
        {
            var rotation = rotationService.RotationColumn(angle);

            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.LeftTop ||
                x.FaciePositionType == FaciePositionType.LeftMiddle ||
                x.FaciePositionType == FaciePositionType.LeftBottom);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }
    }
}
