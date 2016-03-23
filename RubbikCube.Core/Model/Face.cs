using System;
using System.Collections.Generic;
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
    }
}