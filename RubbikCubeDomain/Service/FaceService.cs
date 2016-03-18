using System.Collections.Generic;
using System.Collections.ObjectModel;
using RubiksCube.Entity;
using RubiksCube.Enums;
using RubiksCube.Factory;

namespace RubiksCube.Service
{
    public interface IFaceService
    {
        Face CreateFace(FaceType type);
    }
  
    public class FaceService : IFaceService
    {
        private readonly IFaceFactory faceFactory;
        private readonly IList<Face> faces;

        public FaceService()
        {
            faceFactory = new FaceFactory();
            faces = new List<Face>();
        }

        public Face CreateFace(FaceType type)
        {
            var face = faceFactory.CreateFace(type);
            faces.Add(face);
            return face;
        }
    }
}