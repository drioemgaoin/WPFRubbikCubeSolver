using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Core.Model
{
    public class Face : ICloneable
    {
        public Face()
        {
            Facies = new List<Facie>();
        }

        public FaceType Type { get; set; }

        public IList<Facie> Facies { get; set; }

        public object Clone()
        {
            var face = new Face
            {
                Type = Type
            };

            foreach(var facie in Facies)
            {
                face.Facies.Add((Facie)facie.Clone());    
            }

            return face;
        }

        public IList<Facie> GetRowFacies(RotationType rotation)
        {
            return Facies.Where(x => IsRowMatch(x, rotation)).ToArray();
        }

        public IList<Facie> GetColumnFacies(RotationType rotation)
        {
            return Facies.Where(x => IsColumnMatch(x, rotation)).ToArray();
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine(Type + "-" + Facies.Count);
            foreach (var facie in Facies)
            {
                buffer.AppendLine("-->" + facie);
            }

            return buffer.ToString();
        }

        private static bool IsRowMatch(Facie facie, RotationType rotationType)
        {
            var attribute = ReflectionHelper.GetRotationAttribute(facie.FaciePosition);
            return attribute.Row == rotationType || rotationType == RotationType.All;
        }

        private static bool IsColumnMatch(Facie facie, RotationType rotationType)
        {
            var attribute = ReflectionHelper.GetRotationAttribute(facie.FaciePosition);
            return attribute.Column == rotationType || rotationType == RotationType.All;
        }
    }
}