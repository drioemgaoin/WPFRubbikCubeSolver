using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RubiksCube.Core.Model.Rotations;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;

namespace RubiksCube.Core.Model
{
    public class Cube
    {
        private readonly IDictionary<FaceType, Face> faces = new Dictionary<FaceType, Face>();
        private readonly  RotationFactory rotationFactory = new RotationFactory();

        public Cube()
        {
            var faceFactory = new FaceFactory();
            faces[FaceType.Up] = faceFactory.CreateFace(FaceType.Up);
            faces[FaceType.Back] = faceFactory.CreateFace(FaceType.Back);
            faces[FaceType.Down] = faceFactory.CreateFace(FaceType.Down);
            faces[FaceType.Front] = faceFactory.CreateFace(FaceType.Front);
            faces[FaceType.Left] = faceFactory.CreateFace(FaceType.Left);
            faces[FaceType.Right] = faceFactory.CreateFace(FaceType.Right);
        }

        public Face this[FaceType type] => faces[type];

        public IEnumerable<UIRotation> MixUp()
        {
            var actions = new Func<UIRotation>[]
            {
                () => Rotate(new UpFaceRotationInfo(true)),
                () => Rotate(new UpFaceRotationInfo(false)),
                () => Rotate(new DownFaceRotationInfo(true)),
                () => Rotate(new DownFaceRotationInfo(false)),

                () => Rotate(new LeftFaceRotationInfo(true)),
                () => Rotate(new LeftFaceRotationInfo(false)),
                () => Rotate(new RightFaceRotationInfo(true)),
                () => Rotate(new RightFaceRotationInfo(false)),

                () => Rotate(new FrontFaceRotationInfo(true)),
                () => Rotate(new FrontFaceRotationInfo(false)),
                () => Rotate(new BackFaceRotationInfo(true)),
                () => Rotate(new BackFaceRotationInfo(false))
            };

            var random = new Random();
            for (var i = 0; i < 200; i++)
            {
                var index = random.Next(0, actions.Count());
                yield return actions[index]();
            }
        }

        public UIRotation Rotate(RotationInfo rotationInfo)
        {
            var rotation = rotationFactory.CreateRotation(rotationInfo);
            rotation.Apply(this);

            return new UIRotation(rotation);
        }
        
        public override string ToString()
        {
            var buffer = new StringBuilder();
            foreach(var face in faces.Values)
            {
                buffer.Append(face);
            }

            return buffer.ToString();
        }
    }
}