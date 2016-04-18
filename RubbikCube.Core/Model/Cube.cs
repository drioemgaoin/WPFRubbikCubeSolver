using System;
using System.Collections.Generic;
using System.Text;
using RubiksCube.Core.Model.Rotations;

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