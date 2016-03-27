using System.Collections.Generic;
using System.Linq;
using System.Text;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core.Model
{
    public class Cube
    {
        public Cube()
        {
            var faceFactory = new FaceFactory();
            FrontFace = faceFactory.CreateFace(FaceType.Front);
            LeftFace = faceFactory.CreateFace(FaceType.Left);
            RightFace = faceFactory.CreateFace(FaceType.Right);
            BottomFace = faceFactory.CreateFace(FaceType.Bottom);
            TopFace = faceFactory.CreateFace(FaceType.Top);
            BackFace = faceFactory.CreateFace(FaceType.Back);
        }

        public Face FrontFace { get; }

        public Face LeftFace { get; }

        public Face RightFace { get; }

        public Face BottomFace { get; }

        public Face TopFace { get; }

        public Face BackFace { get; }

        public void Rotate(FaceRotation rotation)
        {
            rotation.Apply(this);
        }

        public Face Find(FaceType faceType)
        {
            switch(faceType)
            {
                case FaceType.Bottom:
                    return BottomFace;
                case FaceType.Back:
                    return BackFace;
                case FaceType.Front:
                    return FrontFace;
                case FaceType.Left:
                    return LeftFace;
                case FaceType.Right:
                    return RightFace;
                case FaceType.Top:
                    return TopFace;
            }

            return null;
        }

        public Face Find(Color color, FaciePositionType faciePosition)
        {
            var faces = new List<Face> { FrontFace, LeftFace, RightFace, BottomFace, TopFace, BackFace };
            foreach (var face in faces)
            {
                if (face.Facies.Any(x => x.FaciePosition == faciePosition && x.Color == Color.White))
                {
                    return face;
                }
            }

            return null;
        }

        public Face Find(Color color)
        {
            var faces = new List<Face> { FrontFace, LeftFace, RightFace, BottomFace, TopFace, BackFace };
            foreach(var face in faces)
            {
                if (face.Facies.Any(x => x.FaciePosition == FaciePositionType.Middle && x.Color == Color.White))
                {
                    return face;
                }
            }

            return null;
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