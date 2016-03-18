using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using WpfApplication.Domain.Enum;

namespace WpfApplication.Domain.Factory
{
    public interface IPositionsFactory
    {
        Point3DCollection CreatePoints(FaceType faceType, FaciePositionType positionType);
    }

    public class PositionsFactory : IPositionsFactory
    {
        public Point3DCollection CreatePoints(FaceType faceType, FaciePositionType positionType)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    return CreatePoints(CreateFrontPositions(), positionType);
                case FaceType.Top:
                    return CreatePoints(CreateTopPositions(), positionType);
                case FaceType.Back:
                    return CreatePoints(CreateBackPositions(), positionType);
                case FaceType.Left:
                    return CreatePoints(CreateLeftPositions(), positionType);
                case FaceType.Right:
                    return CreatePoints(CreateRightPositions(), positionType);
                case FaceType.Bottom:
                    return CreatePoints(CreateBottomPositions(), positionType);
            }

            return new Point3DCollection();
        }

        private static IDictionary<FaciePositionType, string> CreateLeftPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "0 2 0  1 2 0  0 2 -1  1 2 -1";
            positions[FaciePositionType.MiddleTop] = "1 2 0  2 2 0  1 2 -1  2 2 -1";
            positions[FaciePositionType.MiddleBottom] = "-1 2 0  0 2 0  -1 2 -1  0 2 -1";
            positions[FaciePositionType.RightMiddle] = "0 2 1  1 2 1  0 2 0  1 2 0";
            positions[FaciePositionType.RightTop] = "1 2 1  2 2 1  1 2 0  2 2 0";
            positions[FaciePositionType.RightBottom] = "-1 2 1  0 2 1  -1 2 0  0 2 0";
            positions[FaciePositionType.LeftMiddle] = "0 2 -1  1 2 -1  0 2 -2  1 2 -2";
            positions[FaciePositionType.LeftTop] = "1 2 -1  2 2 -1  1 2 -2  2 2 -2";
            positions[FaciePositionType.LeftBottom] = "-1 2 -1  0 2 -1  -1 2 -2  0 2 -2";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateBottomPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "-1 0 -1  -1 0 0  -1 1 -1  -1 1 0";
            positions[FaciePositionType.MiddleTop] = "-1 0 0  -1 0 1  -1 1 0  -1 1 1";
            positions[FaciePositionType.MiddleBottom] = "-1 0 -2  -1 0 -1  -1 1 -2  -1 1 -1";
            positions[FaciePositionType.RightMiddle] = "-1 -1 -1  -1 -1 0  -1 0 -1  -1 0 0";
            positions[FaciePositionType.RightTop] = "-1 -1 0  -1 -1 1  -1 0 0  -1 0 1";
            positions[FaciePositionType.RightBottom] = "-1 -1 -2  -1 -1 -1  -1 0 -2  -1 0 -1";
            positions[FaciePositionType.LeftMiddle] = "-1 1 -1  -1 1 0  -1 2 -1  -1 2 0";
            positions[FaciePositionType.LeftTop] = "-1 1 0  -1 1 1  -1 2 0  -1 2 1";
            positions[FaciePositionType.LeftBottom] = "-1 1 -2  -1 1 -1  -1 2 -2  -1 2 -1";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateBackPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "1 0 -2  0 0 -2  1 1 -2  0 1 -2";
            positions[FaciePositionType.MiddleTop] = "2 0 -2  1 0 -2  2 1 -2  1 1 -2";
            positions[FaciePositionType.MiddleBottom] = "0 0 -2  -1 0 -2  0 1 -2  -1 1 -2";
            positions[FaciePositionType.RightMiddle] = "1 -1 -2  0 -1 -2  1 0 -2  0 0 -2";
            positions[FaciePositionType.RightTop] = "2 -1 -2  1 -1 -2  2 0 -2  1 0 -2";
            positions[FaciePositionType.RightBottom] = "0 -1 -2  -1 -1 -2  0 0 -2  -1 0 -2";
            positions[FaciePositionType.LeftMiddle] = "1 1 -2  0 1 -2  1 2 -2  0 2 -2";
            positions[FaciePositionType.LeftTop] = "2 1 -2  1 1 -2  2 2 -2  1 2 -2";
            positions[FaciePositionType.LeftBottom] = "0 1 -2  -1 1 -2  0 2 -2  -1 2 -2";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateRightPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "0 -1 -1  1 -1 -1  0 -1 0  1 -1 0";
            positions[FaciePositionType.MiddleTop] = "1 -1 -1  2 -1 -1  1 -1 0  2 -1 0";
            positions[FaciePositionType.MiddleBottom] = "-1 -1 -1  0 -1 -1  -1 -1 0  0 -1 0";
            positions[FaciePositionType.RightMiddle] = "0 -1 -2  1 -1 -2  0 -1 -1  1 -1 -1";
            positions[FaciePositionType.RightTop] = "1 -1 -2  2 -1 -2  1 -1 -1  2 -1 -1";
            positions[FaciePositionType.RightBottom] = "-1 -1 -2  0 -1 -2  -1 -1 -1  0 -1 -1";
            positions[FaciePositionType.LeftMiddle] = "0 -1 0  1 -1 0  0 -1 1  1 -1 1";
            positions[FaciePositionType.LeftTop] = "1 -1 0  2 -1 0  1 -1 1  2 -1 1";
            positions[FaciePositionType.LeftBottom] = "-1 -1 0  0 -1 0  -1 -1 1  0 -1 1";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateTopPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "2 0 0  2 0 -1  2 1 0  2 1 -1";
            positions[FaciePositionType.MiddleTop] = "2 0 -1  2 0 -2  2 1 -1  2 1 -2";
            positions[FaciePositionType.MiddleBottom] = "2 0 1  2 0 0  2 1 1  2 1 0";
            positions[FaciePositionType.RightMiddle] = "2 -1 0  2 -1 -1  2 0 0  2 0 -1";
            positions[FaciePositionType.RightTop] = "2 -1 -1  2 -1 -2  2 0 -1  2 0 -2";
            positions[FaciePositionType.RightBottom] = "2 -1 1  2 -1 0  2 0 1  2 0 0";
            positions[FaciePositionType.LeftMiddle] = "2 1 0  2 1 -1  2 2 0  2 2 -1";
            positions[FaciePositionType.LeftTop] = "2 1 -1  2 1 -2  2 2 -1  2 2 -2";
            positions[FaciePositionType.LeftBottom] = "2 1 1  2 1 0  2 2 1  2 2 0";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateFrontPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "0 0 1  1 0 1  0 1 1  1 1 1";
            positions[FaciePositionType.MiddleTop] = "1 0 1  2 0 1  1 1 1  2 1 1";
            positions[FaciePositionType.MiddleBottom] = "-1 0 1  0 0 1  -1 1 1  0 1 1";
            positions[FaciePositionType.RightMiddle] = "0 -1 1  1 -1 1  0 0 1  1 0 1";
            positions[FaciePositionType.RightTop] = "1 -1 1  2 -1 1  1 0 1  2 0 1";
            positions[FaciePositionType.RightBottom] = "-1 -1 1  0 -1 1  -1 0 1  0 0 1";
            positions[FaciePositionType.LeftMiddle] = "0 1 1  1 1 1  0 2 1  1 2 1";
            positions[FaciePositionType.LeftTop] = "1 1 1  2 1 1  1 2 1  2 2 1";
            positions[FaciePositionType.LeftBottom] = "-1 1 1  0 1 1  -1 2 1  0 2 1";
            return positions;
        }

        private static Point3DCollection CreatePoints(IDictionary<FaciePositionType, string> positions, FaciePositionType positionType)
        {
            var points = new Point3DCollection();

            var position = System.Text.RegularExpressions.Regex.Split(positions[positionType], @"\s{2}");

            for (var i = 0; i < position.Length; i++)
            {
                var values = position[i].Split(' ');

                var point = new Point3D(
                    Convert.ToDouble(values[0]),
                    Convert.ToDouble(values[1]),
                    Convert.ToDouble(values[2])
                );

                points.Add(point);
            }    

            return points;
        }
    }
}