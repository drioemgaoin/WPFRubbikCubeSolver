using System.Collections.Generic;
using System.Collections.ObjectModel;
using RubiksCube.Entity;
using RubiksCube.Enums;
using RubiksCube.Factory;

namespace RubiksCube.Service
{
    public interface IFaceService
    {
        IReadOnlyCollection<Face> Faces { get; }

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

        public IReadOnlyCollection<Face> Faces
        {
            get { return new ReadOnlyCollection<Face>(faces); }
        }

        public Face CreateFace(FaceType type)
        {
            var face = faceFactory.CreateFace(type);
            faces.Add(face);
            return face;
        }
    }
}