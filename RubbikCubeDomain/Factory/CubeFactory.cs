using RubiksCube.Entity;
using RubiksCube.Enums;

namespace RubiksCube.Factory
{
    public interface ICubeFactory
    {
        Cube Create();
    }

    public class CubeFactory : ICubeFactory
    {
        private readonly IFaceFactory faceFactory;

        public CubeFactory()
        {
            faceFactory = new FaceFactory();
        }

        public Cube Create()
        {
            return new Cube
            {
                FrontFace = faceFactory.CreateFace(FaceType.Front),
                LeftFace = faceFactory.CreateFace(FaceType.Left),
                RightFace = faceFactory.CreateFace(FaceType.Right),
                BottomFace = faceFactory.CreateFace(FaceType.Bottom),
                TopFace = faceFactory.CreateFace(FaceType.Top),
                BackFace = faceFactory.CreateFace(FaceType.Back)
            };
        }
    }
}