namespace RubiksCube.Core.Model
{
    public enum FaciePositionType
    {
        None = 0,
        [Rotation(LayerType.Second, LayerType.Second)]
        Middle,
        [Rotation(LayerType.First, LayerType.Second)]
        MiddleTop,
        [Rotation(LayerType.Third, LayerType.Second)]
        MiddleBottom,
        [Rotation(LayerType.Second, LayerType.First)]
        LeftMiddle,
        [Rotation(LayerType.First, LayerType.First)]
        LeftTop,
        [Rotation(LayerType.Third, LayerType.First)]
        LeftBottom,
        [Rotation(LayerType.Second, LayerType.Third)]
        RightMiddle,
        [Rotation(LayerType.First, LayerType.Third)]
        RightTop,
        [Rotation(LayerType.Third, LayerType.Third)]
        RightBottom
    }
}