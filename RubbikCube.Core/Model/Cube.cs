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

        public void Rotate(Rotation rotation)
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
    }
}