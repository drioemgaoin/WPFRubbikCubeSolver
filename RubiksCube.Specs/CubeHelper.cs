using System;
using System.Collections.Generic;
using RubiksCube.Core.Model;

namespace RubiksCube.Specs
{
    public static class CubeHelper
    {
        public static IList<Facie> GetLayer(this Cube cube, string face, char axis, string layer)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var axisType = (AxisType)Enum.Parse(typeof(AxisType), axis.ToString());
            var layerType = (LayerType)Enum.Parse(typeof(LayerType), layer);

            switch (axisType)
            {
                case AxisType.X:
                    return cube[faceType].GetXLayer(layerType);
                case AxisType.Y:
                    return cube[faceType].GetYLayer(layerType);
                case AxisType.Z:
                    return cube[faceType].GetZLayer(layerType);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
