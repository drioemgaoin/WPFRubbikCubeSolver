using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RubiksCube.Core.Factory;

namespace RubiksCube.Core.Model
{
    public class Cube
    {
        private readonly IRotationFactory rotationFactory;

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
                        facies[i].AddRange(RotateUp(RotationType.All));
                        break;
                    case Rotation.Right:
                        facies[i].AddRange(RotateRight(RotationType.All));
                        break;
                    case Rotation.Left:
                        facies[i].AddRange(RotateLeft(RotationType.All));
                        break;
                    case Rotation.Down:
                        facies[i].AddRange(RotateDown(RotationType.All));
                        break;
                }
            }

            return facies;
        }

        private IList<Face> RotateRight(RotationType rotationType)
        {
            var matrix = rotationFactory.RotateX(Math.PI / 2);

            var frontFacies = RotateRow(FrontFace, matrix, rotationType);
            var leftFacies = RotateRow(LeftFace, matrix, rotationType);
            var rightFacies = RotateRow(RightFace, matrix, rotationType);
            var backFacies = RotateRow(BackFace, matrix, rotationType);

            Move(LeftFace, FrontFace, leftFacies);
            Move(BackFace, LeftFace, backFacies);
            Move(RightFace, BackFace, rightFacies);
            Move(FrontFace, RightFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(leftFacies)
                .Union(rightFacies)
                .Union(backFacies).ToArray();
        }

        private IList<Face> RotateLeft(RotationType rotationType)
        {
            var matrix = rotationFactory.RotateX(-Math.PI / 2);

            var frontFacies = RotateRow(FrontFace, matrix, rotationType);
            var leftFacies = RotateRow(LeftFace, matrix, rotationType);
            var rightFacies = RotateRow(RightFace, matrix, rotationType);
            var backFacies = RotateRow(BackFace, matrix, rotationType);

            Move(RightFace, FrontFace, rightFacies);
            Move(BackFace, RightFace, backFacies);
            Move(LeftFace, BackFace, leftFacies);
            Move(FrontFace, LeftFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(leftFacies)
                .Union(rightFacies)
                .Union(backFacies).ToArray();
        }

        private IList<Face> RotateUp(RotationType rotationType)
        {
            var matrix = rotationFactory.RotateY(Math.PI / 2);

            var frontFacies = RotateColumn(FrontFace, matrix, rotationType);
            var bottomFacies = RotateColumn(BottomFace, matrix, rotationType);
            var topFacies = RotateColumn(TopFace, matrix, rotationType);
            var backFacies = RotateColumn(BackFace, matrix, rotationType);

            Move(BottomFace, FrontFace, bottomFacies);
            Move(BackFace, BottomFace, backFacies);
            Move(TopFace, BackFace, topFacies);
            Move(FrontFace, TopFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(topFacies)
                .Union(bottomFacies)
                .Union(backFacies).ToArray();
        }

        private IList<Face> RotateDown(RotationType rotationType)
        {
            var matrix = rotationFactory.RotateY(-Math.PI / 2);

            var frontFacies = RotateColumn(FrontFace, matrix, rotationType);
            var bottomFacies = RotateColumn(BottomFace, matrix, rotationType);
            var topFacies = RotateColumn(TopFace, matrix, rotationType);
            var backFacies = RotateColumn(BackFace, matrix, rotationType);

            Move(TopFace, FrontFace, topFacies);
            Move(BackFace, TopFace, backFacies);
            Move(BottomFace, BackFace, bottomFacies);
            Move(FrontFace, BottomFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(topFacies)
                .Union(bottomFacies)
                .Union(backFacies).ToArray();
        }

        private IList<Face> RotateRow(Face face, double[,] matrix, RotationType rotationType)
        {
            var facies = face.Facies.Where(x => IsRowMatch(x, rotationType)).ToList();
            Rotate(facies, matrix);
            return facies.ToArray();
        }

        private IList<Face> RotateColumn(Face face, double[,] matrix, RotationType rotationType)
        {
            var facies = face.Facies.Where(x => IsColumnMatch(x, rotationType)).ToList();
            Rotate(facies, matrix);
            return facies.ToArray();
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