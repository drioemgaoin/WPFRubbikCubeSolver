using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core.Model
{
    public enum FaciePositionType
    {
        None = 0,
        [Rotation(RotationType.Second, RotationType.Second)]
        Middle,
        [Rotation(RotationType.First, RotationType.Second)]
        MiddleTop,
        [Rotation(RotationType.Third, RotationType.Second)]
        MiddleBottom,
        [Rotation(RotationType.Second, RotationType.First)]
        LeftMiddle,
        [Rotation(RotationType.First, RotationType.First)]
        LeftTop,
        [Rotation(RotationType.Third, RotationType.First)]
        LeftBottom,
        [Rotation(RotationType.Second, RotationType.Third)]
        RightMiddle,
        [Rotation(RotationType.First, RotationType.Third)]
        RightTop,
        [Rotation(RotationType.Third, RotationType.Third)]
        RightBottom
    }
}