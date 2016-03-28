using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RubiksCube.Core.Model
{
    public class Face : ICloneable
    {
        private readonly IList<Facie> facies;

        public Face(IList<Facie> facies, FaceType type)
        {
            this.facies = facies;

            Facies = new ReadOnlyCollection<Facie>(facies);
            Type = type;
        }

        public FaceType Type { get; }

        public IReadOnlyCollection<Facie> Facies { get; }

        public object Clone()
        {
            var faciesClone = Facies.Select(facie => (Facie) facie.Clone()).ToList();

            return new Face(faciesClone, Type);            
        }

        public IList<Facie> GetYLayer(LayerType layerType)
        {
            return Facies.Where(x => IsRowMatch(x, layerType)).ToArray();
        }

        public IList<Facie> GetXLayer(LayerType layerType)
        {
            return Facies.Where(x => IsColumnMatch(x, layerType)).ToArray();
        }

        public void Add(Facie facie)
        {
            facies.Add(facie);
        }

        public void Remove(Facie facie)
        {
            facies.Remove(facie);
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

        private static bool IsRowMatch(Facie facie, LayerType layerType)
        {
            var attribute = ReflectionHelper.GetRotationAttribute(facie.FaciePosition);
            return attribute.Row == layerType || layerType == LayerType.All;
        }

        private static bool IsColumnMatch(Facie facie, LayerType layerType)
        {
            var attribute = ReflectionHelper.GetRotationAttribute(facie.FaciePosition);
            return attribute.Column == layerType || layerType == LayerType.All;
        }
    }
}