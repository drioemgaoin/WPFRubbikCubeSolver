using System.Collections.Generic;

namespace RubiksCube.Core.Model
{
    public interface IFaceFactory
    {
        Face CreateFace(FaceType type);
    }

    public class FaceFactory : IFaceFactory
    {
        public Face CreateFace(FaceType type)
        {
            switch (type)
            {
                case FaceType.Front:
                    return CreateFace(type, Color.White);
                case FaceType.Up:
                    return CreateFace(type, Color.Orange);
                case FaceType.Down:
                    return CreateFace(type, Color.Red);
                case FaceType.Left:
                    return CreateFace(type, Color.Green);
                case FaceType.Right:
                    return CreateFace(type, Color.Blue);
                case FaceType.Back:
                    return CreateFace(type, Color.Yellow);
            }

            return null;
        }

        private static Face CreateFace(FaceType faceType, Color color)
        {
            var facies = new List<Facie>
            {
                CreateFacie(faceType, FaciePositionType.Middle, color),
                CreateFacie(faceType, FaciePositionType.MiddleTop, color),
                CreateFacie(faceType, FaciePositionType.MiddleBottom, color),
                CreateFacie(faceType, FaciePositionType.RightMiddle, color),
                CreateFacie(faceType, FaciePositionType.RightTop, color),
                CreateFacie(faceType, FaciePositionType.RightBottom, color),
                CreateFacie(faceType, FaciePositionType.LeftMiddle, color),
                CreateFacie(faceType, FaciePositionType.LeftTop, color),
                CreateFacie(faceType, FaciePositionType.LeftBottom, color)
            };

            return new Face(facies, faceType);
        }

        private static Facie CreateFacie(FaceType faceType, FaciePositionType faciePositionType, Color color)
        {
            return new Facie
            {
                Key = string.Format("{0}{1}", faceType, faciePositionType),
                Color = color,
                FaciePosition = faciePositionType
            };
        }
    }
}