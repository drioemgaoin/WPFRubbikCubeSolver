using System;
using System.Collections.Generic;
using System.Linq;
using RubiksCube.Entity;
using RubiksCube.Enums;

namespace RubiksCube.Service
{
    public interface ICubeService
    {
        IList<Face> RotateOnRightSide(Cube cube, RotationType rotationType);
        IList<Face> RotateOnLeftSide(Cube cube, RotationType rotationType);
        IList<Face> RotateOnUpSide(Cube cube, RotationType rotationType);
        IList<Face> RotateOnDownSide(Cube cube, RotationType rotationType);

        //double[,] RotateOnRightSide(Cube cube);
        //double[,] RotateOnLeftSide(Cube cube);
        //double[,] RotateOnUpSide(Cube cube);
        //double[,] RotateOnDownSide(Cube cube);
    }

    public class CubeService : ICubeService
    {
        private readonly IRotationService rotationService;

        public CubeService()
        {
            rotationService = new RotationService();
        }

        public IList<Face> RotateOnRightSide(Cube cube, RotationType rotationType)
        {
            return RotateRow(cube, rotationType, Math.PI / 4);
        }

        public IList<Face> RotateOnLeftSide(Cube cube, RotationType rotationType)
        {
            return RotateRow(cube, rotationType, -Math.PI / 4);
        }

        public IList<Face> RotateOnUpSide(Cube cube, RotationType rotationType)
        {
            return RotateColumn(cube, rotationType, Math.PI / 4);
        }

        public IList<Face> RotateOnDownSide(Cube cube, RotationType rotationType)
        {
            return RotateColumn(cube, rotationType, -Math.PI / 4);
        }

        private IList<Face> RotateRow(Cube cube, RotationType rotationType, double angle)
        {
            switch (rotationType)
            {
                case RotationType.All:
                    var faces = new List<Face>();
                    faces.AddRange(RotateFirstRow(cube, angle));
                    faces.AddRange(RotateSecondRow(cube, angle));
                    faces.AddRange(RotateThirdRow(cube, angle));
                    return faces;
                case RotationType.First:
                    return RotateFirstRow(cube, angle);
            }

            return new Face[0];
        }

        private IList<Face> RotateColumn(Cube cube, RotationType rotationType, double angle)
        {
            switch (rotationType)
            {
                case RotationType.All:
                    var faces = new List<Face>();
                    faces.AddRange(RotateFirstColumn(cube, angle));
                    faces.AddRange(RotateSecondColumn(cube, angle));
                    faces.AddRange(RotateThirdColumn(cube, angle));
                    return faces;
                case RotationType.First:
                    return RotateFirstColumn(cube, angle);
            }

            return new Face[0];
        }

        private IList<Face> RotateFirstRow(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateFirstRow(cube.FrontFace, angle));
            facies.AddRange(RotateFirstRow(cube.RightFace, angle));
            facies.AddRange(RotateFirstRow(cube.BackFace, angle));
            facies.AddRange(RotateFirstRow(cube.LeftFace, angle));
            return facies;
        }

        private IList<Face> RotateSecondRow(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateSecondRow(cube.FrontFace, angle));
            facies.AddRange(RotateSecondRow(cube.RightFace, angle));
            facies.AddRange(RotateSecondRow(cube.BackFace, angle));
            facies.AddRange(RotateSecondRow(cube.LeftFace, angle));
            return facies;
        }

        private IList<Face> RotateThirdRow(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateThirdRow(cube.FrontFace, angle));
            facies.AddRange(RotateThirdRow(cube.RightFace, angle));
            facies.AddRange(RotateThirdRow(cube.BackFace, angle));
            facies.AddRange(RotateThirdRow(cube.LeftFace, angle));
            return facies;
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

        private IEnumerable<Face> RotateSecondRow(Face face, double angle)
        {
            var rotation = rotationService.RotationRow(angle);

            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.LeftMiddle ||
                x.FaciePositionType == FaciePositionType.Middle ||
                x.FaciePositionType == FaciePositionType.RightMiddle);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }

        private IEnumerable<Face> RotateThirdRow(Face face, double angle)
        {
            var rotation = rotationService.RotationRow(angle);

            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.LeftBottom ||
                x.FaciePositionType == FaciePositionType.MiddleBottom ||
                x.FaciePositionType == FaciePositionType.RightBottom);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }

        private IList<Face> RotateFirstColumn(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateFirstColumn(cube.FrontFace, angle));
            facies.AddRange(RotateFirstColumn(cube.TopFace, angle));
            facies.AddRange(RotateFirstColumn(cube.BackFace, angle));
            facies.AddRange(RotateFirstColumn(cube.BottomFace, angle));
            return facies;
        }

        private IList<Face> RotateSecondColumn(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateSecondColumn(cube.FrontFace, angle));
            facies.AddRange(RotateSecondColumn(cube.TopFace, angle));
            facies.AddRange(RotateSecondColumn(cube.BackFace, angle));
            facies.AddRange(RotateSecondColumn(cube.BottomFace, angle));
            return facies;
        }

        private IList<Face> RotateThirdColumn(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateThirdColumn(cube.FrontFace, angle));
            facies.AddRange(RotateThirdColumn(cube.TopFace, angle));
            facies.AddRange(RotateThirdColumn(cube.BackFace, angle));
            facies.AddRange(RotateThirdColumn(cube.BottomFace, angle));
            return facies;
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

        private IEnumerable<Face> RotateSecondColumn(Face face, double angle)
        {
            var rotation = rotationService.RotationColumn(angle);

            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.MiddleTop ||
                x.FaciePositionType == FaciePositionType.Middle ||
                x.FaciePositionType == FaciePositionType.MiddleBottom);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }

        private IEnumerable<Face> RotateThirdColumn(Face face, double angle)
        {
            var rotation = rotationService.RotationColumn(angle);

            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.RightMiddle ||
                x.FaciePositionType == FaciePositionType.RightMiddle ||
                x.FaciePositionType == FaciePositionType.RightBottom);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }
    }
}