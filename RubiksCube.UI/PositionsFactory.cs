using System.Collections.Generic;
using RubiksCube.Core.Model;

namespace RubiksCube.UI
{
    public interface IPositionsFactory
    {
        IDictionary<FaciePositionType, string> CreatePositions(FaceType faceType);
    }

    public class PositionsFactory : IPositionsFactory
    {
        public IDictionary<FaciePositionType, string> CreatePositions(FaceType faceType)
        {
            switch (faceType)
            {
                case FaceType.Front:
                    return CreateFrontPositions();
                case FaceType.Up:
                    return CreateTopPositions();
                case FaceType.Back:
                    return CreateBackPositions();
                case FaceType.Left:
                    return CreateLeftPositions();
                case FaceType.Right:
                    return CreateRightPositions();
                case FaceType.Down:
                    return CreateBottomPositions();
            }

            return new Dictionary<FaciePositionType, string>();
        }

        private static IDictionary<FaciePositionType, string> CreateLeftPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "0 2 0  1 2 0  0 2 -1  1 2 -1";
            positions[FaciePositionType.MiddleUp] = "1 2 0  2 2 0  1 2 -1  2 2 -1";
            positions[FaciePositionType.MiddleDown] = "-1 2 0  0 2 0  -1 2 -1  0 2 -1";
            positions[FaciePositionType.RightMiddle] = "0 2 1  1 2 1  0 2 0  1 2 0";
            positions[FaciePositionType.RightUp] = "1 2 1  2 2 1  1 2 0  2 2 0";
            positions[FaciePositionType.RightDown] = "-1 2 1  0 2 1  -1 2 0  0 2 0";
            positions[FaciePositionType.LeftMiddle] = "0 2 -1  1 2 -1  0 2 -2  1 2 -2";
            positions[FaciePositionType.LeftUp] = "1 2 -1  2 2 -1  1 2 -2  2 2 -2";
            positions[FaciePositionType.LeftDown] = "-1 2 -1  0 2 -1  -1 2 -2  0 2 -2";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateBottomPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "-1 0 -1  -1 0 0  -1 1 -1  -1 1 0";
            positions[FaciePositionType.MiddleDown] = "-1 0 0  -1 0 1  -1 1 0  -1 1 1";
            positions[FaciePositionType.MiddleUp] = "-1 0 -2  -1 0 -1  -1 1 -2  -1 1 -1";
            positions[FaciePositionType.RightMiddle] = "-1 -1 -1  -1 -1 0  -1 0 -1  -1 0 0";
            positions[FaciePositionType.RightDown] = "-1 -1 0  -1 -1 1  -1 0 0  -1 0 1";
            positions[FaciePositionType.RightUp] = "-1 -1 -2  -1 -1 -1  -1 0 -2  -1 0 -1";
            positions[FaciePositionType.LeftMiddle] = "-1 1 -1  -1 1 0  -1 2 -1  -1 2 0";
            positions[FaciePositionType.LeftDown] = "-1 1 0  -1 1 1  -1 2 0  -1 2 1";
            positions[FaciePositionType.LeftUp] = "-1 1 -2  -1 1 -1  -1 2 -2  -1 2 -1";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateBackPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "1 0 -2  0 0 -2  1 1 -2  0 1 -2";
            positions[FaciePositionType.MiddleUp] = "2 0 -2  1 0 -2  2 1 -2  1 1 -2";
            positions[FaciePositionType.MiddleDown] = "0 0 -2  -1 0 -2  0 1 -2  -1 1 -2";
            positions[FaciePositionType.RightMiddle] = "1 -1 -2  0 -1 -2  1 0 -2  0 0 -2";
            positions[FaciePositionType.RightUp] = "2 -1 -2  1 -1 -2  2 0 -2  1 0 -2";
            positions[FaciePositionType.RightDown] = "0 -1 -2  -1 -1 -2  0 0 -2  -1 0 -2";
            positions[FaciePositionType.LeftMiddle] = "1 1 -2  0 1 -2  1 2 -2  0 2 -2";
            positions[FaciePositionType.LeftUp] = "2 1 -2  1 1 -2  2 2 -2  1 2 -2";
            positions[FaciePositionType.LeftDown] = "0 1 -2  -1 1 -2  0 2 -2  -1 2 -2";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateRightPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "0 -1 -1  1 -1 -1  0 -1 0  1 -1 0";
            positions[FaciePositionType.MiddleUp] = "1 -1 -1  2 -1 -1  1 -1 0  2 -1 0";
            positions[FaciePositionType.MiddleDown] = "-1 -1 -1  0 -1 -1  -1 -1 0  0 -1 0";
            positions[FaciePositionType.RightMiddle] = "0 -1 -2  1 -1 -2  0 -1 -1  1 -1 -1";
            positions[FaciePositionType.RightUp] = "1 -1 -2  2 -1 -2  1 -1 -1  2 -1 -1";
            positions[FaciePositionType.RightDown] = "-1 -1 -2  0 -1 -2  -1 -1 -1  0 -1 -1";
            positions[FaciePositionType.LeftMiddle] = "0 -1 0  1 -1 0  0 -1 1  1 -1 1";
            positions[FaciePositionType.LeftUp] = "1 -1 0  2 -1 0  1 -1 1  2 -1 1";
            positions[FaciePositionType.LeftDown] = "-1 -1 0  0 -1 0  -1 -1 1  0 -1 1";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateTopPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "2 0 0  2 0 -1  2 1 0  2 1 -1";
            positions[FaciePositionType.MiddleUp] = "2 0 -1  2 0 -2  2 1 -1  2 1 -2";
            positions[FaciePositionType.MiddleDown] = "2 0 1  2 0 0  2 1 1  2 1 0";
            positions[FaciePositionType.RightMiddle] = "2 -1 0  2 -1 -1  2 0 0  2 0 -1";
            positions[FaciePositionType.RightUp] = "2 -1 -1  2 -1 -2  2 0 -1  2 0 -2";
            positions[FaciePositionType.RightDown] = "2 -1 1  2 -1 0  2 0 1  2 0 0";
            positions[FaciePositionType.LeftMiddle] = "2 1 0  2 1 -1  2 2 0  2 2 -1";
            positions[FaciePositionType.LeftUp] = "2 1 -1  2 1 -2  2 2 -1  2 2 -2";
            positions[FaciePositionType.LeftDown] = "2 1 1  2 1 0  2 2 1  2 2 0";
            return positions;
        }

        private static IDictionary<FaciePositionType, string> CreateFrontPositions()
        {
            var positions = new Dictionary<FaciePositionType, string>();
            positions[FaciePositionType.Middle] = "0 0 1  1 0 1  0 1 1  1 1 1";
            positions[FaciePositionType.MiddleUp] = "1 0 1  2 0 1  1 1 1  2 1 1";
            positions[FaciePositionType.MiddleDown] = "-1 0 1  0 0 1  -1 1 1  0 1 1";
            positions[FaciePositionType.RightMiddle] = "0 -1 1  1 -1 1  0 0 1  1 0 1";
            positions[FaciePositionType.RightUp] = "1 -1 1  2 -1 1  1 0 1  2 0 1";
            positions[FaciePositionType.RightDown] = "-1 -1 1  0 -1 1  -1 0 1  0 0 1";
            positions[FaciePositionType.LeftMiddle] = "0 1 1  1 1 1  0 2 1  1 2 1";
            positions[FaciePositionType.LeftUp] = "1 1 1  2 1 1  1 2 1  2 2 1";
            positions[FaciePositionType.LeftDown] = "-1 1 1  0 1 1  -1 2 1  0 2 1";
            return positions;
        }
    }
}