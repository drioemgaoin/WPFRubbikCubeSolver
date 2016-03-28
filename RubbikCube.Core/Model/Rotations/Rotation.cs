using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core.Model.Rotations
{
    public abstract class Rotation
    {
        private readonly uint times;

        protected Rotation(double angle, uint times)
        {
            this.times = times;

            Angle = angle;
            Movements = new List<List<Facie>>();
            RotationMatrixFactory = new RotationMatrixFactory();
        }

        public IList<List<Facie>> Movements { get; }

        protected double Angle { get; }

        protected abstract IEnumerable<FaceType> MovingFaces { get; }

        protected IRotationMatrixFactory RotationMatrixFactory { get; }

        public abstract double[,] GetRotationMatrix(double angle);

        protected abstract IEnumerable<Facie> GetMovingFacies(Face face);

        protected abstract void Move(Cube cube, FaceType faceType, Facie facies);

        public void Apply(Cube cube)
        {
            for(var i = 0; i < times; i++)
            {
                var move = ApplyCore(cube).ToList();
                Movements.Add(move.Clone().ToList());
            }
        }

        protected virtual IList<Facie> ApplyCore(Cube cube)
        {
            var facies = new List<Facie>();

            var matrix = GetRotationMatrix(Angle);
            var impactedFacies = new Dictionary<FaceType, IEnumerable<Facie>>();
            foreach (var faceType in MovingFaces)
            {
                var face = cube[faceType];
                var items = GetMovingFacies(face).ToArray();
                impactedFacies.Add(faceType, items);
                facies.AddRange(items);
            }

            foreach(var impactedFacie in impactedFacies)
            {
                foreach(var facie in impactedFacie.Value)
                {
                    facie.PreviousRotation = facie.Rotation;
                    facie.Rotation = facie.Rotation == null ? matrix  : MatrixHelper.Multiply(facie.Rotation, matrix);
                    Move(cube, impactedFacie.Key, facie);
                }
            }

            return facies;
        }        
    }
}