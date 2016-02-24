using System.Collections.Generic;
using RubbikCubeDomain.Enums;

namespace RubbikCubeDomain.Factory
{
    public interface IPositionsFactory
    {
        IDictionary<FaciePositionType, string> CreatePositions(FaceType faceType, FaciePositionType positionType);
    }

    public class PositionsFactory : IPositionsFactory
    {
        public IDictionary<FaciePositionType, string> CreatePositions(FaceType faceType, FaciePositionType positionType)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    return CreateFrontPositions();
                case FaceType.Top:
                    return CreateTopPositions();
                case FaceType.Back:
                    return CreateBackPositions();
                case FaceType.Left:
                    return CreateLeftPositions();
                case FaceType.Right:
                    return CreateRightPositions();
                case FaceType.Bottom:
                    return CreateBottomPositions();
            }

            return new Dictionary<FaciePositionType, string>();
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
    }
}