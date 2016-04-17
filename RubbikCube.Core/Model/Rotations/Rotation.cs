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

        protected abstract IEnumerable<FaceType> AxisMovingFaces { get; }

        protected abstract IEnumerable<FaceType> AxisAdjacentFaces { get; }

        public abstract double[,] CreateMatrix(double angle);

        protected abstract IEnumerable<Facie> GetMovingFacies(Face face);

        protected abstract void Move(Cube cube, FaceType faceType, Facie facie);

        protected abstract void FlipPosition(Facie facie, FaceType faceType);

        public void Apply(Cube cube)
        {
            for(var i = 0; i < times; i++)
            {
                var move = ApplyCore(cube).ToList();
                Moves.Add(move.Clone().ToList());
            }
            System.Diagnostics.Debug.WriteLine(cube);
        }

        protected virtual IList<Facie> ApplyCore(Cube cube)
        {
            var facies = new List<Facie>();

            var matrix = CreateMatrix(Angle);
            var movingFacies = new Dictionary<FaceType, IEnumerable<Facie>>();
            foreach (var faceType in AxisAdjacentFaces)
            {
                var face = cube[faceType];
                var items = GetMovingFacies(face).ToArray();
                movingFacies.Add(faceType, items);
                facies.AddRange(items);
            }

            foreach (var faceType in AxisMovingFaces)
            {
                var faciesRotated = cube[faceType].Facies;
                foreach (var facie in faciesRotated)
                {
                    facie.PreviousRotation = facie.Rotation;
                    facie.Rotation = facie.Rotation == null ? matrix : MatrixHelper.Multiply(facie.Rotation, matrix);
                    FlipPosition(facie, faceType);
                }
                facies.AddRange(faciesRotated);
            }

            foreach (var face in movingFacies)
            {
                foreach (var facie in face.Value)
                {
                    facie.PreviousRotation = facie.Rotation;
                    facie.Rotation = facie.Rotation == null ? matrix : MatrixHelper.Multiply(facie.Rotation, matrix);

                    cube[face.Key].Remove(facie);
                    Move(cube, face.Key, facie);
                }
            }

            return facies;
        }        
    }
}