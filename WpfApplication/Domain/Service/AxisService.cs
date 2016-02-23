using System;
using System.Collections.Generic;
using System.Linq;
using WpfApplication.Domain.Entity;
using WpfApplication.Domain.Enum;

namespace WpfApplication.Domain.Service
{
    public interface IAxisService
    {
        Axes Create(FaceType faceType, FaciePositionType faciePositionType);

        Axes Get(FaceType faceType, FaciePositionType faciePositionType);

        IList<Tuple<FaceType, Axes>> GetAxis(FaciePositionType faciePositionType);
    }

    public class Axes
    {
        public Axes()
        {
            AxisX = new Axis(1, 0, 0);    
            AxisY = new Axis(0, 1, 0);    
            AxisZ = new Axis(0, 0, 1);    
        }

        public Axis AxisX { get; private set; }
        public Axis AxisY { get; private set; }
        public Axis AxisZ { get; private set; }
    }

    public class AxisService : IAxisService
    {
        private readonly IDictionary<Tuple<FaceType, FaciePositionType>, Axes> facesAxes;

        public AxisService()
        {
            facesAxes = new Dictionary<Tuple<FaceType, FaciePositionType>, Axes>();
        }

        public Axes Create(FaceType faceType, FaciePositionType faciePositionType)
        {
            var key = new Tuple<FaceType, FaciePositionType>(faceType, faciePositionType);

            var faceAxes = new Axes();
            facesAxes.Add(key, faceAxes);
            return faceAxes;
        }

        public Axes Get(FaceType faceType, FaciePositionType faciePositionType)
        {
            var key = new Tuple<FaceType, FaciePositionType>(faceType, faciePositionType);
            return facesAxes[key];
        }

        public IList<Tuple<FaceType, Axes>> GetAxis(FaciePositionType faciePositionType)
        {
            return facesAxes.Where(x => faciePositionType.HasFlag(x.Key.Item2))
                .Select(x => new Tuple<FaceType, Axes>(x.Key.Item1, x.Value))
                .ToList();
        }
    }
}
