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

        public IList<List<Facie>> Rotate(Rotation rotation)
        {
            var facies = new List<List<Facie>>();
            for (var i = 0; i < rotation.Times; i++)
            {
                facies.Add(new List<Facie>());
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

        private IEnumerable<Facie> RotateRight(Rotation rotation)
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

        private IEnumerable<Facie> RotateLeft(Rotation rotation)
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

        private IEnumerable<Facie> RotateUp(Rotation rotation)
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

        private IEnumerable<Facie> RotateDown(Rotation rotation)
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

        private IList<Facie> RotateRow(Face face, double[,] matrix, RotationType rotationType)
        {
            var facies = face.GetRowFacies(rotationType).ToList();
            Rotate(facies, matrix);
            return facies.ToArray();
        }

        private IList<Facie> RotateColumn(Face face, double[,] matrix, RotationType rotationType)
        {
            var facies = face.GetColumnFacies(rotationType).ToList();
            Rotate(facies, matrix);
            return facies;
        }

        private static void Rotate(IEnumerable<Facie> facies, double[,] matrix)
        {
            foreach (var facie in facies)
            {
                facie.Rotation = facie.Rotation == null ? matrix : MatrixHelper.Multiply(facie.Rotation, matrix);
            }
        }

        private static void Move(Face faceSource, Face faceTarget, IList<Facie> facies)
        {
            foreach (var facie in facies)
            {
                faceSource.Facies.Remove(facie);
            }

            foreach (var facie in facies)
            {
                faceTarget.Facies.Add(facie);
                Move(faceSource.Type, faceTarget.Type, facie);
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

        public static void Move(FaceType source, FaceType target, Facie facie)
        {
            if ((source == FaceType.Back && target == FaceType.Top) ||
                (source == FaceType.Front && target == FaceType.Bottom) ||
                (source == FaceType.Bottom && target == FaceType.Front) ||
                (source == FaceType.Top && target == FaceType.Back))
            {
                if(facie.FaciePosition == FaciePositionType.LeftTop)
                {
                    facie.FaciePosition = FaciePositionType.LeftBottom;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftBottom)
                {
                    facie.FaciePosition = FaciePositionType.LeftTop;
                }
                else if (facie.FaciePosition == FaciePositionType.MiddleTop)
                {
                    facie.FaciePosition = FaciePositionType.MiddleBottom;
                }
                else if (facie.FaciePosition == FaciePositionType.MiddleBottom)
                {
                    facie.FaciePosition = FaciePositionType.MiddleTop;
                }
                else if (facie.FaciePosition == FaciePositionType.RightTop)
                {
                    facie.FaciePosition = FaciePositionType.RightBottom;
                }
                else if (facie.FaciePosition == FaciePositionType.RightBottom)
                {
                    facie.FaciePosition = FaciePositionType.RightTop;
                }

            }
            else if ((source == FaceType.Back && target == FaceType.Left) ||
                    (source == FaceType.Right && target == FaceType.Back) ||
                    (source == FaceType.Back && target == FaceType.Right) ||
                    (source == FaceType.Left && target == FaceType.Back))
            {
                if (facie.FaciePosition == FaciePositionType.LeftTop)
                {
                    facie.FaciePosition = FaciePositionType.RightTop;
                }
                else if (facie.FaciePosition == FaciePositionType.RightTop)
                {
                    facie.FaciePosition = FaciePositionType.LeftTop;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftMiddle)
                {
                    facie.FaciePosition = FaciePositionType.RightMiddle;
                }
                else if (facie.FaciePosition == FaciePositionType.RightMiddle)
                {
                    facie.FaciePosition = FaciePositionType.LeftMiddle;
                }
                else if (facie.FaciePosition == FaciePositionType.LeftBottom)
                {
                    facie.FaciePosition = FaciePositionType.RightBottom;
                }
                else if (facie.FaciePosition == FaciePositionType.RightBottom)
                {
                    facie.FaciePosition = FaciePositionType.LeftBottom;
                }
            }
        }
    }
}