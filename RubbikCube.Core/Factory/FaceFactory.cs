using System;
using System.Collections.Generic;
using System.Windows.Media;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Factory
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
                    return CreateFace(type, Colors.White);
                case FaceType.Top:
                    return CreateFace(type, Colors.Orange);
                case FaceType.Bottom:
                    return CreateFace(type, Colors.Red);
                case FaceType.Left:
                    return CreateFace(type, Colors.Green);
                case FaceType.Right:
                    return CreateFace(type, Colors.Blue);
                case FaceType.Back:
                    return CreateFace(type, Colors.Yellow);
            }

            return null;
        }

        private static Face CreateFace(FaceType faceType, Color color)
        {
            return new Face
            {
                Type = faceType, 
                Color = color,
                Facies = new List<Face> {
                    CreateSubFace(faceType, FaciePositionType.Middle, color),        
                    CreateSubFace(faceType, FaciePositionType.MiddleTop, color),        
                    CreateSubFace(faceType, FaciePositionType.MiddleBottom, color),        
                    CreateSubFace(faceType, FaciePositionType.RightMiddle, color),        
                    CreateSubFace(faceType, FaciePositionType.RightTop, color),        
                    CreateSubFace(faceType, FaciePositionType.RightBottom, color),        
                    CreateSubFace(faceType, FaciePositionType.LeftMiddle, color),        
                    CreateSubFace(faceType, FaciePositionType.LeftTop, color),        
                    CreateSubFace(faceType, FaciePositionType.LeftBottom, color)
                }
            };
        }

        private static Face CreateSubFace(FaceType faceType, FaciePositionType faciePositionType, Color color)
        {
            return new Face
            {
                Key = String.Format("{0}{1}", faceType, faciePositionType),
                Type = faceType,
                Color = color,
                FaciePositionType = faciePositionType
            };
        }
    }
}