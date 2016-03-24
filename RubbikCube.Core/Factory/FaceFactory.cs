using System;
using System.Collections.Generic;
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
                    return CreateFace(type, Color.White);
                case FaceType.Top:
                    return CreateFace(type, Color.Orange);
                case FaceType.Bottom:
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
            return new Face
            {
                Type = faceType, 
                Facies = new List<Facie> {
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

        private static Facie CreateSubFace(FaceType faceType, FaciePositionType faciePositionType, Color color)
        {
            return new Facie
            {
                Key = String.Format("{0}{1}", faceType, faciePositionType),
                Color = color,
                FaciePosition = faciePositionType
            };
        }
    }
}