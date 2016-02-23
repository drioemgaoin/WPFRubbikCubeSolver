using System.Collections.Generic;
using System.Linq;
using WpfApplication.Domain.Enum;
using WpfApplication.Domain.Factory;
using WpfApplication.Domain.Service;

namespace WpfApplication.Domain
{
    public interface IFaceService
    {
        Face CreateFace(FaceType type);

        void RotateRight();

        void RotateLeft();

        void RotateUp();

        void RotateDown();

        void RotateRowRight(int index);

        void RotateRowLeft(int index);

        void RotateColumnUp(int index);

        void RotateColumnDown(int index);
    }
  
    public class FaceService : IFaceService
    {
        private readonly IFaceFactory faceFactory;
        private readonly IAxisService axisService;
        private readonly IList<Face> faces;

        public FaceService(IAxisService axisService)
        {
            faceFactory = new FaceFactory();
            faces = new List<Face>();

            this.axisService = axisService;
        }

        public Face CreateFace(FaceType type)
        {
            var face = faceFactory.CreateFace(type);
            faces.Add(face);
            return face;
        }

        public void RotateRight()
        {
            var axes = axisService.Get(FaceType.None, FaciePositionType.None);
            axes.AxisX.Angle += 45;
        }

        public void RotateLeft()
        {
            var axes = axisService.Get(FaceType.None, FaciePositionType.None);
            axes.AxisX.Angle -= 45;
        }

        public void RotateUp()
        {
            var axes = axisService.Get(FaceType.None, FaciePositionType.None);
            axes.AxisY.Angle += 45;
        }

        public void RotateDown()
        {
            var axes = axisService.Get(FaceType.None, FaciePositionType.None);
            axes.AxisY.Angle -= 45;
        }

        public void RotateRowRight(int index)
        {
            var axes = axisService.GetAxis(FaciePositionType.LeftTop | FaciePositionType.MiddleTop | FaciePositionType.RightTop);
            foreach (var axis in axes.Where(x => x.Item1 != FaceType.Top && x.Item1 != FaceType.Bottom))
            {
                axis.Item2.AxisX.Angle += 45;
            }
        }

        public void RotateRowLeft(int index)
        {
            //var axes = axisService.GetAxis(FaciePositionType.LeftTop | FaciePositionType.MiddleTop | FaciePositionType.RightTop);
            //foreach (var axis in axes)
            //{
            //    axis.AxisX.Angle -= 45;
            //}
        }

        public void RotateColumnUp(int index)
        {
            
        }

        public void RotateColumnDown(int index)
        {
            
        }
    }
}