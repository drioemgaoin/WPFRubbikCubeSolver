using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Core.Model.Rotations
{
    public abstract class FaceRotation
    {
        public const string Up = "Up";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Down = "Down";
        public const string Forward = "Forward";
        public const string RightWhole = "RightWhole";
        public const string LeftWhole = "LeftWhole";
        public const string UpWhole = "UpWhole";
        public const string DownWhole = "DownWhole";

        public const string CounterClockwise = "CounterClockwise";
        public const string Clockwise = "Clockwise";

        private readonly double angle;
        private readonly uint times;

        protected FaceRotation(string way, double angle, uint times)
        {
            this.angle = way == CounterClockwise ? angle : -angle;
            this.times = times;
            Way = way;

            Movements = new List<List<Facie>>();

            RotationMatrixFactory = new RotationMatrixFactory();
        }

        public IList<List<Facie>> Movements { get; }

        public string Way { get; }

        protected IRotationMatrixFactory RotationMatrixFactory { get; }

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

            var matrix = GetRotationMatrix(angle);
            var impactedFacies = new Dictionary<FaceType, IEnumerable<Facie>>();
            foreach (var faceType in GetImpactedFaceTypes())
            {
                var face = cube.Find(faceType);
                var items = GetImpactedFacies(face).ToArray();
                impactedFacies.Add(faceType, items);
                facies.AddRange(items);
            }

            foreach(var impactedFacie in impactedFacies)
            {
                foreach(var facie in impactedFacie.Value)
                {
                    facie.PreviousRotation = facie.Rotation;
                    facie.Rotation = facie.Rotation == null 
                        ? matrix 
                        : MatrixHelper.Multiply(facie.Rotation, matrix);
                    Move(cube, impactedFacie.Key, facie, angle > 0);
                }
            }

            return facies;
        }

        public abstract double[, ] GetRotationMatrix(double angle);

        protected abstract IEnumerable<FaceType> GetImpactedFaceTypes();

        protected abstract IEnumerable<Facie> GetImpactedFacies(Face face);

        protected abstract void Move(Cube cube, FaceType faceType, Facie facie, bool isPositiveRotation);
    }
}