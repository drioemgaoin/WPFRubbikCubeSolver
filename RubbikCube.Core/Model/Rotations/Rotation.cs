using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core.Model.Rotations
{
    public abstract class Rotation
    {
        private readonly uint times;

        protected Rotation(LayerType layerType, double angle, uint times)
        {
            this.times = times;

            LayerType = layerType;
            Angle = angle;
            Moves = new List<List<Facie>>();
        }

        public IList<List<Facie>> Moves { get; }

        protected double Angle { get; }

        protected LayerType LayerType { get; }

        protected abstract IEnumerable<FaceType> MovingFaces { get; }

        public abstract double[,] CreateMatrix(double angle);

        protected abstract IEnumerable<Facie> GetMovingFacies(Face face);

        protected abstract void Move(Cube cube, FaceType faceType, Facie facies);

        public void Apply(Cube cube)
        {
            for(var i = 0; i < times; i++)
            {
                var move = ApplyCore(cube).ToList();
                Moves.Add(move.Clone().ToList());
            }
        }

        protected virtual IList<Facie> ApplyCore(Cube cube)
        {
            var facies = new List<Facie>();

            var matrix = CreateMatrix(Angle);
            var movingFacies = new Dictionary<FaceType, IEnumerable<Facie>>();
            foreach (var faceType in MovingFaces)
            {
                var face = cube[faceType];
                var items = GetMovingFacies(face).ToArray();
                movingFacies.Add(faceType, items);
                facies.AddRange(items);
            }

            foreach(var face in movingFacies)
            {
                foreach(var facie in face.Value)
                {
                    facie.PreviousRotation = facie.Rotation;
                    facie.Rotation = facie.Rotation == null ? matrix  : MatrixHelper.Multiply(facie.Rotation, matrix);

                    cube[face.Key].Remove(facie);
                    Move(cube, face.Key, facie);
                }
            } 

            return facies;
        }        
    }
}