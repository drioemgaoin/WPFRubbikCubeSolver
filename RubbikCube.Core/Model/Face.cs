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

        public IList<CubeLayerType> GetRows(Color color)
        {
            var rows = new List<CubeLayerType>();
            if(GetRowFacies(CubeLayerType.First).Any(x => x.Color == color))
            {
                rows.Add(CubeLayerType.First);
            }

            if (GetRowFacies(CubeLayerType.Second).Any(x => x.Color == color))
            {
                rows.Add(CubeLayerType.Second);
            }

            if (GetRowFacies(CubeLayerType.Third).Any(x => x.Color == color))
            {
                rows.Add(CubeLayerType.Third);
            }

            return rows;
        }

        public IList<Facie> GetRowFacies(CubeLayerType layerType)
        {
            return Facies.Where(x => IsRowMatch(x, layerType)).ToArray();
        }

        public IList<Facie> GetColumnFacies(CubeLayerType layerType)
        {
            return Facies.Where(x => IsColumnMatch(x, layerType)).ToArray();
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

        private static bool IsRowMatch(Facie facie, CubeLayerType layerType)
        {
            var attribute = ReflectionHelper.GetRotationAttribute(facie.FaciePosition);
            return attribute.Row == layerType || layerType == CubeLayerType.All;
        }

        private static bool IsColumnMatch(Facie facie, CubeLayerType layerType)
        {
            var attribute = ReflectionHelper.GetRotationAttribute(facie.FaciePosition);
            return attribute.Column == layerType || layerType == CubeLayerType.All;
        }
    }
}