using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RubiksCube.Core.Factory;

namespace RubiksCube.Core.Model
{
    public enum MoveType
    {
        None,
        Right,
        Left,
        Up,
        Down
    }

    public class Cube
    {
        private readonly IRotationFactory rotationFactory;
        private MoveType moveType;

        public Cube()
        {
            rotationFactory = new RotationFactory();

            FrontFace = new Face();
            LeftFace = new Face();
            RightFace = new Face();
            BottomFace = new Face();
            TopFace = new Face();
            BackFace = new Face();
        }

        public Face FrontFace { get; set; }
        public Face LeftFace { get; set; }
        public Face RightFace { get; set; }
        public Face BottomFace { get; set; }
        public Face TopFace { get; set; }
        public Face BackFace { get; set; }

        public IList<List<Face>> Rotate(Rotation rotation)
        {
            var facies = new List<List<Face>>();
            for (var i = 0; i < rotation.Times; i++)
            {
                facies.Add(new List<Face>());
                switch (rotation.Direction)
                {
                    case Rotation.Up:
                        facies[i].AddRange(RotateUp(rotation));
                        break;
                    case Rotation.Right:
                        facies[i].AddRange(RotateRight(rotation));
                        break;
                    case Rotation.Left:
                        facies[i].AddRange(RotateLeft(rotation));
                        break;
                    case Rotation.Down:
                        facies[i].AddRange(RotateDown(rotation));
                        break;
                }
            }

            return facies;
        }

        private IEnumerable<Face> RotateRight(Rotation rotation)
        {
            var matrix = rotationFactory.RotateX(rotation.Angle);

            var frontFacies = RotateRow(FrontFace, matrix, rotation.Type);
            var leftFacies = RotateRow(LeftFace, matrix, rotation.Type);
            var rightFacies = RotateRow(RightFace, matrix, rotation.Type);
            var backFacies = RotateRow(BackFace, matrix, rotation.Type);

            if (rotation.IsMatchFace)
            {
                Move(LeftFace, FrontFace, leftFacies);
                Move(BackFace, LeftFace, backFacies);
                Move(RightFace, BackFace, rightFacies);
                Move(FrontFace, RightFace, frontFacies);
            }

            return frontFacies
                .Union(leftFacies)
                .Union(rightFacies)
                .Union(backFacies).Clone();
        }

        private IEnumerable<Face> RotateLeft(Rotation rotation)
        {
            var matrix = rotationFactory.RotateX(-rotation.Angle);

            var frontFacies = RotateRow(FrontFace, matrix, rotation.Type);
            var leftFacies = RotateRow(LeftFace, matrix, rotation.Type);
            var rightFacies = RotateRow(RightFace, matrix, rotation.Type);
            var backFacies = RotateRow(BackFace, matrix, rotation.Type);

            if (rotation.IsMatchFace)
            {
                Move(RightFace, FrontFace, rightFacies);
                Move(BackFace, RightFace, backFacies);
                Move(LeftFace, BackFace, leftFacies);
                Move(FrontFace, LeftFace, frontFacies);
            }

            return frontFacies
                .Union(leftFacies)
                .Union(rightFacies)
                .Union(backFacies).Clone();
        }

        private IEnumerable<Face> RotateUp(Rotation rotation)
        {
            var matrix = rotationFactory.RotateY(rotation.Angle);

            var frontFacies = RotateColumn(FrontFace, matrix, rotation.Type);
            var bottomFacies = RotateColumn(BottomFace, matrix, rotation.Type);
            var topFacies = RotateColumn(TopFace, matrix, rotation.Type);
            var backFacies = RotateColumn(BackFace, matrix, rotation.Type);

            if (rotation.IsMatchFace)
            {
                Move(BottomFace, FrontFace, bottomFacies);
                Move(BackFace, BottomFace, backFacies);
                Move(TopFace, BackFace, topFacies);
                Move(FrontFace, TopFace, frontFacies);
            }

            return frontFacies
                .Union(topFacies)
                .Union(bottomFacies)
                .Union(backFacies).Clone();
        }

        private IEnumerable<Face> RotateDown(Rotation rotation)
        {
            var matrix = rotationFactory.RotateY(-rotation.Angle);

            var frontFacies = RotateColumn(FrontFace, matrix, rotation.Type);
            var bottomFacies = RotateColumn(BottomFace, matrix, rotation.Type);
            var topFacies = RotateColumn(TopFace, matrix, rotation.Type);
            var backFacies = RotateColumn(BackFace, matrix, rotation.Type);

            if (rotation.IsMatchFace)
            {
                Move(TopFace, FrontFace, topFacies);
                Move(BackFace, TopFace, backFacies);
                Move(BottomFace, BackFace, bottomFacies);
                Move(FrontFace, BottomFace, frontFacies);
            }

            return frontFacies
                .Union(topFacies)
                .Union(bottomFacies)
                .Union(backFacies).Clone();
        }

        private IList<Face> RotateRow(Face face, double[,] matrix, RotationType rotationType)
        {
            var facies = face.Facies.Where(x => IsRowMatch(x, rotationType)).ToList();
            Rotate(facies, matrix);
            return facies.ToArray();
        }

        private IList<Face> RotateColumn(Face face, double[,] matrix, RotationType rotationType)
        {
            var facies = face.Facies.Where(x => IsColumnMatch(x, rotationType)).ToArray();
            Rotate(facies, matrix);
            return facies;
        }

        private static void Rotate(IEnumerable<Face> facies, double[,] matrix)
        {
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? matrix : MatrixHelper.Multiply(facie.Rotation, matrix);
            }
        }

        private static void Move(Face source, Face target, IList<Face> facies)
        {
            foreach (var facie in facies)
            {
                source.Facies.Remove(facie);
            }

            foreach (var facie in facies)
            {
                facie.Move(target.Type);
                target.Facies.Add(facie);
            }
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.Append(FrontFace);
            buffer.Append(RightFace);
            buffer.Append(BackFace);
            buffer.Append(LeftFace);
            buffer.Append(TopFace);
            buffer.Append(BottomFace);
            return buffer.ToString();
        }

        private static bool IsRowMatch(Face facie, RotationType rotationType)
        {
            switch (rotationType)
            {
                case RotationType.All:
                    return true;
                case RotationType.First:
                    return facie.FaciePositionType == FaciePositionType.LeftTop ||
                           facie.FaciePositionType == FaciePositionType.MiddleTop ||
                           facie.FaciePositionType == FaciePositionType.RightTop;
                case RotationType.Second:
                    return facie.FaciePositionType == FaciePositionType.LeftMiddle ||
                           facie.FaciePositionType == FaciePositionType.Middle ||
                           facie.FaciePositionType == FaciePositionType.RightMiddle;
                case RotationType.Third:
                    return facie.FaciePositionType == FaciePositionType.LeftBottom ||
                           facie.FaciePositionType == FaciePositionType.MiddleBottom ||
                           facie.FaciePositionType == FaciePositionType.RightBottom;
            }

            return false;
        }

        private static bool IsColumnMatch(Face facie, RotationType rotationType)
        {
            switch (rotationType)
            {
                case RotationType.All:
                    return true;
                case RotationType.First:
                    return facie.FaciePositionType == FaciePositionType.LeftTop ||
                           facie.FaciePositionType == FaciePositionType.LeftMiddle ||
                           facie.FaciePositionType == FaciePositionType.LeftBottom;
                case RotationType.Second:
                    return facie.FaciePositionType == FaciePositionType.MiddleTop ||
                           facie.FaciePositionType == FaciePositionType.Middle ||
                           facie.FaciePositionType == FaciePositionType.MiddleBottom;
                case RotationType.Third:
                    return facie.FaciePositionType == FaciePositionType.RightTop ||
                           facie.FaciePositionType == FaciePositionType.RightMiddle ||
                           facie.FaciePositionType == FaciePositionType.RightBottom;
            }

            return false;
        }
    }
}