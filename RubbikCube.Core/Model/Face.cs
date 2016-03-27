using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RubiksCube.Core.Model.Rotations;

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

        public IList<RotationType> GetRows(Color color)
        {
            var rows = new List<RotationType>();
            if(GetRowFacies(RotationType.First).Any(x => x.Color == color))
            {
                rows.Add(RotationType.First);
            }

            if (GetRowFacies(RotationType.Second).Any(x => x.Color == color))
            {
                rows.Add(RotationType.Second);
            }

            if (GetRowFacies(RotationType.Third).Any(x => x.Color == color))
            {
                rows.Add(RotationType.Third);
            }

            return rows;
        }

        public IList<Facie> GetRowFacies(RotationType rotation)
        {
            return Facies.Where(x => IsRowMatch(x, rotation)).ToArray();
        }

        public IList<Facie> GetColumnFacies(RotationType rotation)
        {
            return Facies.Where(x => IsColumnMatch(x, rotation)).ToArray();
        }

        public void Add(Facie facie)
        {
            Facies.Add(facie);
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