using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    var facies = RotateFirstColumn(cube, angle);
                    return facies;
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
            MoveRow(cube, facies, angle > 0);


            System.Diagnostics.Debug.WriteLine("MOVE ROW");
            System.Diagnostics.Debug.WriteLine(cube.FrontFace);
            System.Diagnostics.Debug.WriteLine(cube.RightFace);
            System.Diagnostics.Debug.WriteLine(cube.BackFace);
            System.Diagnostics.Debug.WriteLine(cube.LeftFace);
            System.Diagnostics.Debug.WriteLine("END MOVE ROW");
            
            return facies;
        }

        private IList<Face> RotateSecondRow(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateSecondRow(cube.FrontFace, angle));
            facies.AddRange(RotateSecondRow(cube.RightFace, angle));
            facies.AddRange(RotateSecondRow(cube.BackFace, angle));
            facies.AddRange(RotateSecondRow(cube.LeftFace, angle));
            MoveRow(cube, facies, angle > 0);

            return facies;
        }

        private IList<Face> RotateThirdRow(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateThirdRow(cube.FrontFace,  angle));
            facies.AddRange(RotateThirdRow(cube.RightFace, angle));
            facies.AddRange(RotateThirdRow(cube.BackFace, angle));
            facies.AddRange(RotateThirdRow(cube.LeftFace, angle));
            MoveRow(cube, facies, angle > 0);

            return facies;
        }

        private IEnumerable<Face> RotateFirstRow(Face face, double angle)
        {
            var rotation = rotationService.RotationRow(angle);
            
            var facies = face.Facies.Where(x =>
                x.FaciePositionType == FaciePositionType.LeftTop ||
                x.FaciePositionType == FaciePositionType.MiddleTop ||
                x.FaciePositionType == FaciePositionType.RightTop).ToList();
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
            MoveColumn(cube, facies, angle > 0);

            System.Diagnostics.Debug.WriteLine("MOVE COLUMN");
            System.Diagnostics.Debug.WriteLine(cube.FrontFace);
            System.Diagnostics.Debug.WriteLine(cube.TopFace);
            System.Diagnostics.Debug.WriteLine(cube.BackFace);
            System.Diagnostics.Debug.WriteLine(cube.BottomFace);
            System.Diagnostics.Debug.WriteLine("END MOVE COLUMN");

            return facies;
        }

        private IList<Face> RotateSecondColumn(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateSecondColumn(cube.FrontFace, angle));
            facies.AddRange(RotateSecondColumn(cube.TopFace, angle));
            facies.AddRange(RotateSecondColumn(cube.BackFace, angle));
            facies.AddRange(RotateSecondColumn(cube.BottomFace, angle));
            MoveColumn(cube, facies, angle > 0);

            return facies;
        }

        private IList<Face> RotateThirdColumn(Cube cube, double angle)
        {
            var facies = new List<Face>();
            facies.AddRange(RotateThirdColumn(cube.FrontFace, angle));
            facies.AddRange(RotateThirdColumn(cube.TopFace, angle));
            facies.AddRange(RotateThirdColumn(cube.BackFace, angle));
            facies.AddRange(RotateThirdColumn(cube.BottomFace, angle));
            MoveColumn(cube, facies, angle > 0);

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
                x.FaciePositionType == FaciePositionType.RightTop ||
                x.FaciePositionType == FaciePositionType.RightMiddle ||
                x.FaciePositionType == FaciePositionType.RightBottom);
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? rotation : MatrixHelper.Multiply(facie.Rotation, rotation);
                yield return facie;
            }
        }

        private void MoveRow(Cube cube, IEnumerable<Face> facies, bool moveRight)
        {
            var frontFacie = facies.First(x => x.Type == FaceType.Front);
            var isMoving = !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationRow(0)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationRow(Math.PI / 2)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationRow(Math.PI)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationRow((3 * Math.PI) / 2)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationRow(2 * Math.PI));

            var faciesToMove = facies.Where(x => x.Type != FaceType.Top && x.Type != FaceType.Bottom).ToList();
            foreach (var facie in faciesToMove)
            {
                if (isMoving)
                {
                    facie.Move = moveRight ? MoveType.Right : MoveType.Left;
                    continue;
                }

                if (facie.Move == MoveType.Left && moveRight)
                {
                    facie.Move = MoveType.None;
                    continue;
                }

                if (facie.Move == MoveType.Right && !moveRight)
                {
                    facie.Move = MoveType.None;
                    continue;
                }

                facie.Move = MoveType.None;

                switch (facie.Type)
                {
                    case FaceType.Front:
                        cube.FrontFace.Facies.Remove(facie);
                        if (moveRight)
                        {
                            facie.Type = FaceType.Right;
                            cube.RightFace.Facies.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Left;
                            cube.LeftFace.Facies.Add(facie);
                        }
                        break;
                    case FaceType.Right:
                        cube.RightFace.Facies.Remove(facie);
                        if (moveRight)
                        {
                            facie.Type = FaceType.Back;
                            cube.BackFace.Facies.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Front;
                            cube.FrontFace.Facies.Add(facie);
                        }
                        break;
                    case FaceType.Back:
                        cube.BackFace.Facies.Remove(facie);
                        if (moveRight)
                        {
                            facie.Type = FaceType.Left;
                            cube.LeftFace.Facies.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Right;
                            cube.RightFace.Facies.Add(facie);
                        }
                        break;
                    case FaceType.Left:
                        cube.LeftFace.Facies.Remove(facie);
                        if (moveRight)
                        {
                            facie.Type = FaceType.Front;
                            cube.FrontFace.Facies.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Back;
                            cube.BackFace.Facies.Add(facie);
                        }
                        break; 
                }
            }
        }

        private void MoveColumn(Cube cube, IEnumerable<Face> facies, bool moveUp)
        {
            var frontToAdd = new List<Face>();
            var frontToRemove = new List<Face>();
            var topToAdd = new List<Face>();
            var topToRemove = new List<Face>();
            var backToAdd = new List<Face>();
            var backToRemove = new List<Face>();
            var bottomToAdd = new List<Face>();
            var bottomToRemove = new List<Face>();

            var frontFacie = facies.First(x => x.Type == FaceType.Front);
            var isMoving = !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationColumn(0)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationColumn(Math.PI / 2)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationColumn(Math.PI)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationColumn((3 * Math.PI) / 2)) &&
                           !MatrixHelper.Equal(frontFacie.Rotation, rotationService.RotationColumn(2 * Math.PI));

            var faciesToMove = facies.Where(x => x.Type != FaceType.Left && x.Type != FaceType.Right).ToList();
            foreach (var facie in faciesToMove)
            {
                if (isMoving)
                {
                    facie.Move = moveUp ? MoveType.Up : MoveType.Down;
                    continue;
                }

                if (facie.Move == MoveType.Down && moveUp)
                {
                    facie.Move = MoveType.None;
                    continue;
                }

                if (facie.Move == MoveType.Up && !moveUp)
                {
                    facie.Move = MoveType.None;
                    continue;
                }

                facie.Move = MoveType.None;

                switch (facie.Type)
                {
                    case FaceType.Front:
                        frontToRemove.Add(facie);
                        if (moveUp)
                        {
                            facie.Type = FaceType.Top;
                            topToAdd.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Bottom;
                            bottomToAdd.Add(facie);
                        }

                        break;
                    case FaceType.Top:
                        topToRemove.Add(facie);
                        if (moveUp)
                        {
                            facie.Type = FaceType.Back;
                            backToAdd.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Front;
                            frontToAdd.Add(facie);
                        }

                        break;
                    case FaceType.Back:
                        backToRemove.Add(facie);
                        if (moveUp)
                        {
                            facie.Type = FaceType.Bottom;
                            bottomToAdd.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Top;
                            topToAdd.Add(facie);
                        }

                        break;
                    case FaceType.Bottom:
                        bottomToRemove.Add(facie);
                        if (moveUp)
                        {
                            facie.Type = FaceType.Front;
                            frontToAdd.Add(facie);
                        }
                        else
                        {
                            facie.Type = FaceType.Back;
                            backToAdd.Add(facie);
                        }

                        break;
                }
            }

            foreach (var face in frontToRemove)
            {
                cube.FrontFace.Facies.Remove(face);
            }
            foreach (var face in frontToAdd)
            {
                cube.FrontFace.Facies.Add(face);
            }

            foreach (var face in topToRemove)
            {
                cube.TopFace.Facies.Remove(face);
            }
            foreach (var face in topToAdd)
            {
                cube.TopFace.Facies.Add(face);
            }

            foreach (var face in backToRemove)
            {
                cube.BackFace.Facies.Remove(face);
            }
            foreach (var face in backToAdd)
            {
                cube.BackFace.Facies.Add(face);
            }

            foreach (var face in bottomToRemove)
            {
                cube.BottomFace.Facies.Remove(face);
            }
            foreach (var face in bottomToAdd)
            {
                cube.BottomFace.Facies.Add(face);
            }
        }
    }
}