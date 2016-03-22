using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace RubiksCube.Core.Model
{
    public class Face : ICloneable
    {
        private double[,] rotation;

        public Face()
        {
            Facies = new List<Face>();
        }

        public double[,] PreviousRotation { get; private set; }

        public double[,] Rotation
        {
            get { return rotation; }
            set
            {
                if (rotation != null)
                {
                    PreviousRotation = MatrixHelper.Copy(rotation);
                }

                rotation = value;
            }
        }

        public string Key { get; set; }

        public FaceType Type { get; set; }

        public FaciePositionType FaciePosition { get; set; }

        public Color Color { get; set; } // TODO: Replace with new model type to protect integrity and break the UI dependency

        public IList<Face> Facies { get; set; }

        public void Move(FaceType target)
        {
            if ((Type == FaceType.Back && target == FaceType.Top) ||
                (Type == FaceType.Front && target == FaceType.Bottom) ||
                (Type == FaceType.Bottom && target == FaceType.Front) ||
                (Type == FaceType.Top && target == FaceType.Back))
            {
                switch (FaciePosition)
                {
                    case FaciePositionType.LeftTop:
                        FaciePosition = FaciePositionType.LeftBottom;
                        break;
                    case FaciePositionType.LeftBottom:
                        FaciePosition = FaciePositionType.LeftTop;
                        break;
                    case FaciePositionType.MiddleTop:
                        FaciePosition = FaciePositionType.MiddleBottom;
                        break;
                    case FaciePositionType.MiddleBottom:
                        FaciePosition = FaciePositionType.MiddleTop;
                        break;
                    case FaciePositionType.RightTop:
                        FaciePosition = FaciePositionType.RightBottom;
                        break;
                    case FaciePositionType.RightBottom:
                        FaciePosition = FaciePositionType.RightTop;
                        break;
                }
            }

            if ((Type == FaceType.Back && target == FaceType.Left) ||
                (Type == FaceType.Right && target == FaceType.Back) ||
                (Type == FaceType.Back && target == FaceType.Right) ||
                (Type == FaceType.Left && target == FaceType.Back))
            {
                switch (FaciePosition)
                {
                    case FaciePositionType.LeftTop:
                        FaciePosition = FaciePositionType.RightTop;
                        break;
                    case FaciePositionType.RightTop:
                        FaciePosition = FaciePositionType.LeftTop;
                        break;
                    case FaciePositionType.LeftMiddle:
                        FaciePosition = FaciePositionType.RightMiddle;
                        break;
                    case FaciePositionType.RightMiddle:
                        FaciePosition = FaciePositionType.LeftMiddle;
                        break;
                    case FaciePositionType.LeftBottom:
                        FaciePosition = FaciePositionType.RightBottom;
                        break;
                    case FaciePositionType.RightBottom:
                        FaciePosition = FaciePositionType.LeftBottom;
                        break;
                }
            }

            Type = target;
        }

        public string ColorName
        {
            get
            {
                if (Color == Colors.Blue)
                {
                    return "Blue";
                }

                if (Color == Colors.Red)
                {
                    return "Red";
                }

                if (Color == Colors.Green)
                {
                    return "Green";
                }

                if (Color == Colors.Orange)
                {
                    return "Orange";
                }

                if (Color == Colors.White)
                {
                    return "White";
                }

                if (Color == Colors.Yellow)
                {
                    return "Yellow";
                }

                return "NA";
            }
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine(Type + "-" + FaciePosition + "-" + ColorName + "=" + Facies.Count);
            foreach (var face in Facies)
            {
                buffer.AppendLine("-->" + face);
            }

            return buffer.ToString();
        }

        public object Clone()
        {
            var face = new Face
            {
                PreviousRotation = PreviousRotation,
                Rotation = Rotation,
                Key = Key,
                Type = Type,
                FaciePosition = FaciePosition,
                Color = Color,
            };

            foreach(var facie in Facies)
            {
                face.Facies.Add(facie.Clone() as Face);    
            }

            return face;
        }
    }
}