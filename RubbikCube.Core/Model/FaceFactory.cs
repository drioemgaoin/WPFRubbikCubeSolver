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
                    return CreateWhiteFace(type);
                case FaceType.Up:
                    return CreateOrangeFace(type);
                case FaceType.Down:
                    return CreateRedFace(type);
                case FaceType.Left:
                    return CreateGreenFace(type);
                case FaceType.Right:
                    return CreateBlueFace(type);
                case FaceType.Back:
                    return CreateYellowFace(type);
            }

            return null;
        }

        private static Face CreateWhiteFace(FaceType faceType)
        {
            var facies = new List<Facie>
            {
                CreateCorner(faceType, FaciePositionType.LeftUp, Color.White, Color.Green, Color.Orange),
                CreateEdge(faceType, FaciePositionType.MiddleUp, Color.White, Color.Orange),
                CreateCorner(faceType, FaciePositionType.RightUp, Color.White, Color.Blue, Color.Orange),
                CreateEdge(faceType, FaciePositionType.LeftMiddle, Color.White, Color.Green),
                CreateFacie(faceType, FaciePositionType.Center, Color.White),
                CreateEdge(faceType, FaciePositionType.RightMiddle, Color.White, Color.Blue),
                CreateCorner(faceType, FaciePositionType.LeftDown, Color.White, Color.Green, Color.Red),
                CreateEdge(faceType, FaciePositionType.MiddleDown, Color.White, Color.Red),
                CreateCorner(faceType, FaciePositionType.RightDown, Color.White, Color.Red, Color.Blue)
            };

            return new Face(facies, faceType);
        }

        private static Face CreateOrangeFace(FaceType faceType)
        {
            var facies = new List<Facie>
            {
                CreateCorner(faceType, FaciePositionType.LeftUp, Color.Orange, Color.Green, Color.Yellow),
                CreateEdge(faceType, FaciePositionType.MiddleUp, Color.Orange, Color.Yellow),
                CreateCorner(faceType, FaciePositionType.RightUp, Color.Orange, Color.Blue, Color.Yellow),
                CreateEdge(faceType, FaciePositionType.LeftMiddle, Color.Orange, Color.Green),
                CreateFacie(faceType, FaciePositionType.Center, Color.Orange),
                CreateEdge(faceType, FaciePositionType.RightMiddle, Color.Orange, Color.Blue),
                CreateCorner(faceType, FaciePositionType.LeftDown, Color.Orange, Color.Green, Color.White),
                CreateEdge(faceType, FaciePositionType.MiddleDown, Color.Orange, Color.White),
                CreateCorner(faceType, FaciePositionType.RightDown, Color.Orange, Color.Blue, Color.White)
            };

            return new Face(facies, faceType);
        }

        private static Face CreateGreenFace(FaceType faceType)
        {
            var facies = new List<Facie>
            {
                CreateCorner(faceType, FaciePositionType.LeftUp, Color.Green, Color.Yellow, Color.Orange),
                CreateEdge(faceType, FaciePositionType.MiddleUp, Color.Green, Color.Orange),
                CreateCorner(faceType, FaciePositionType.RightUp, Color.Green, Color.Orange, Color.White),
                CreateEdge(faceType, FaciePositionType.LeftMiddle, Color.Green, Color.Yellow),
                CreateFacie(faceType, FaciePositionType.Center, Color.Green),
                CreateEdge(faceType, FaciePositionType.RightMiddle, Color.Green, Color.White),
                CreateCorner(faceType, FaciePositionType.LeftDown, Color.Green, Color.Yellow, Color.Red),
                CreateEdge(faceType, FaciePositionType.MiddleDown, Color.Green, Color.Red),
                CreateCorner(faceType, FaciePositionType.RightDown, Color.Green, Color.Red, Color.White)
            };

            return new Face(facies, faceType);
        }

        private static Face CreateBlueFace(FaceType faceType)
        {
            var facies = new List<Facie>
            {
                CreateCorner(faceType, FaciePositionType.LeftUp, Color.Blue, Color.White, Color.Orange),
                CreateEdge(faceType, FaciePositionType.MiddleUp, Color.Blue, Color.Orange),
                CreateCorner(faceType, FaciePositionType.RightUp, Color.Blue, Color.Orange, Color.Yellow),
                CreateEdge(faceType, FaciePositionType.LeftMiddle, Color.Blue, Color.White),
                CreateFacie(faceType, FaciePositionType.Center, Color.Blue),
                CreateEdge(faceType, FaciePositionType.RightMiddle, Color.Blue, Color.Yellow),
                CreateCorner(faceType, FaciePositionType.LeftDown, Color.Blue, Color.White, Color.Red),
                CreateEdge(faceType, FaciePositionType.MiddleDown, Color.Blue, Color.Red),
                CreateCorner(faceType, FaciePositionType.RightDown, Color.Blue, Color.Red, Color.Yellow)
            };

            return new Face(facies, faceType);
        }

        private static Face CreateYellowFace(FaceType faceType)
        {
            var facies = new List<Facie>
            {
                CreateCorner(faceType, FaciePositionType.LeftUp, Color.Yellow, Color.Green, Color.Orange),
                CreateEdge(faceType, FaciePositionType.MiddleUp, Color.Yellow, Color.Orange),
                CreateCorner(faceType, FaciePositionType.RightUp, Color.Yellow, Color.Orange, Color.Blue),
                CreateEdge(faceType, FaciePositionType.LeftMiddle, Color.Yellow, Color.Green),
                CreateFacie(faceType, FaciePositionType.Center, Color.Yellow),
                CreateEdge(faceType, FaciePositionType.RightMiddle, Color.Yellow, Color.Blue),
                CreateCorner(faceType, FaciePositionType.LeftDown, Color.Yellow, Color.Green, Color.Red),
                CreateEdge(faceType, FaciePositionType.MiddleDown, Color.Yellow, Color.Red),
                CreateCorner(faceType, FaciePositionType.RightDown, Color.Yellow, Color.Red, Color.Blue)
            };

            return new Face(facies, faceType);
        }

        private static Face CreateRedFace(FaceType faceType)
        {
            var facies = new List<Facie>
            {
                CreateCorner(faceType, FaciePositionType.LeftUp, Color.Red, Color.Green, Color.Yellow),
                CreateEdge(faceType, FaciePositionType.MiddleUp, Color.Red, Color.Yellow),
                CreateCorner(faceType, FaciePositionType.RightUp, Color.Red, Color.Yellow, Color.Blue),
                CreateEdge(faceType, FaciePositionType.LeftMiddle, Color.Red, Color.Green),
                CreateFacie(faceType, FaciePositionType.Center, Color.Red),
                CreateEdge(faceType, FaciePositionType.RightMiddle, Color.Red, Color.Blue),
                CreateCorner(faceType, FaciePositionType.LeftDown, Color.Red, Color.Green, Color.White),
                CreateEdge(faceType, FaciePositionType.MiddleDown, Color.Red, Color.White),
                CreateCorner(faceType, FaciePositionType.RightDown, Color.Red, Color.White, Color.Blue)
            };

            return new Face(facies, faceType);
        }

        private static Facie CreateEdge(FaceType faceType, FaciePositionType positionType, Color color, Color adjacentColor)
        {
            return new Edge(positionType, color, adjacentColor)
            {
                Key = $"{faceType}{positionType}"
            };
        }

        private static Facie CreateCorner(FaceType faceType, FaciePositionType positionType, Color color, Color adjacentColor1, Color adjacentColor2)
        {
            return new Corner(positionType, color, adjacentColor1, adjacentColor2)
            {
                Key = $"{faceType}{positionType}"
            };
        }

        private static Facie CreateFacie(FaceType faceType, FaciePositionType positionType, Color color)
        {
            return new Facie(color, positionType)
            {
                Key = $"{faceType}{positionType}"
            };
        }
    }
}