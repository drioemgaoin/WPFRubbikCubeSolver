using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using WpfApplication.Domain.Enum;
using WpfApplication.Domain.Factory;

namespace WpfApplication.Domain
{
    public interface IFaceService
    {
        Face CreateFace(FaceType type);

        void RotateRight();

        void RotateLeft();

        void RotateUp();

        void RotateDown();

        void RotateRowRight(int index);

        void RotateRowLeft(int index);

        void RotateColumnUp(int index);

        void RotateColumnDown(int index);
    }

    public enum MoveType
    {
        None,
        Right,
        Left,
        Up,
        Down,
        RowRight,
        RowLeft,
        ColumnUp,
        ColumnDown
    }

    public class FaceService : IFaceService
    {
        private readonly IFaceFactory faceFactory;
        private readonly IList<Face> faces;
        private FaceType currentFace;

        public FaceService()
        {
            faceFactory = new FaceFactory();
            faces = new List<Face>();
            currentFace = FaceType.Front;
        }

        public Face CreateFace(FaceType type)
        {
            var face = faceFactory.CreateFace(type);
            faces.Add(face);
            return face;
        }

        public void RotateRight()
        {
            //foreach (var face in faces)
            //{
            //    face.AbscisseAngle += 45;
            //}
        }

        private Matrix3D CalculateRotationMatrix(double x, double y, double z)
        {
            var matrix = new Matrix3D();

            matrix.Rotate(new Quaternion(new Vector3D(1, 0, 0), x));
            matrix.Rotate(new Quaternion(new Vector3D(0, 1, 0) * matrix, y));
            matrix.Rotate(new Quaternion(new Vector3D(0, 0, 1) * matrix, z));

            return matrix;
        }

        public void RotateLeft()
        {
            //foreach (var face in faces)
            //{
            //    face.AbscisseAngle -= 45;
            //}
        }

        public void RotateUp()
        {
            //foreach (var face in faces)
            //{
            //    face.OrdinateAngle += 45;
            //}
        }

        public void RotateDown()
        {
            //foreach (var face in faces)
            //{
            //    face.OrdinateAngle -= 45;
            //}
        }

        public void RotateRowRight(int index)
        {
            //var facies = new List<Face>();
            //foreach (var face in faces)
            //{
            //    facies.AddRange(face.GetRow(index).Where(x => x.Type != FaceType.Top && x.Type != FaceType.Bottom));
            //}

            //foreach (var facie in facies)
            //{
            //    facie.AbscisseAngle += 90;
            //    facie.Type = GetNewFaceType(facie.Type, MoveType.RowRight);
            //}
        }

        public void RotateRowLeft(int index)
        {
            //var facies = new List<Face>();
            //foreach (var face in faces)
            //{
            //    facies.AddRange(face.GetRow(index).Where(x => x.Type != FaceType.Top && x.Type != FaceType.Bottom));
            //}

            //foreach (var facie in facies)
            //{
            //    facie.AbscisseAngle -= 90;
            //    facie.Type = GetNewFaceType(facie.Type, MoveType.RowLeft);
            //}
        }

        public void RotateColumnUp(int index)
        {
            //var facies = new List<Face>();
            //foreach (var face in faces)
            //{
            //    facies.AddRange(face.GetColumn(index).Where(x => x.Type != FaceType.Left && x.Type != FaceType.Right));
            //}

            //foreach (var facie in facies)
            //{
            //    facie.OrdinateAngle += 90;
            //    facie.Type = GetNewFaceType(facie.Type, MoveType.ColumnUp);
            //}
        }

        public void RotateColumnDown(int index)
        {
            //var facies = new List<Face>();
            //foreach (var face in faces)
            //{
            //    facies.AddRange(face.GetColumn(index).Where(x => x.Type != FaceType.Left && x.Type != FaceType.Right));
            //}

            //foreach (var facie in facies)
            //{
            //    facie.OrdinateAngle -= 90;
            //    facie.Type = GetNewFaceType(facie.Type, MoveType.ColumnDown);
            //}
        }

        private static FaceType GetNewFaceType(FaceType faceType, MoveType moveType)
        {
            if (moveType == MoveType.RowRight || moveType == MoveType.Right)
            {
                switch (faceType)
                {
                    case FaceType.Front:
                        return FaceType.Right;
                    case FaceType.Right:
                        return FaceType.Back;
                    case FaceType.Back:
                        return FaceType.Left;
                    case FaceType.Left:
                        return FaceType.Front;
                }
            }

            if (moveType == MoveType.RowLeft || moveType == MoveType.Left)
            {
                switch (faceType)
                {
                    case FaceType.Front:
                        return FaceType.Left;
                    case FaceType.Left:
                        return FaceType.Back;
                    case FaceType.Back:
                        return FaceType.Right;
                    case FaceType.Right:
                        return FaceType.Front;
                }
            }

            if (moveType == MoveType.ColumnUp)
            {
                switch (faceType)
                {
                    case FaceType.Front:
                        return FaceType.Top;
                    case FaceType.Top:
                        return FaceType.Back;
                    case FaceType.Back:
                        return FaceType.Bottom;
                    case FaceType.Bottom:
                        return FaceType.Front;
                }
            }

            if (moveType == MoveType.ColumnDown)
            {
                switch (faceType)
                {
                    case FaceType.Front:
                        return FaceType.Bottom;
                    case FaceType.Bottom:
                        return FaceType.Back;
                    case FaceType.Back:
                        return FaceType.Top;
                    case FaceType.Top:
                        return FaceType.Front;
                }
            }

            return faceType;
        }
    }
}