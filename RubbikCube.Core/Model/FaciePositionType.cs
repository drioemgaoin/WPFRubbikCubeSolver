namespace RubiksCube.Core.Model
{
    public enum FaciePositionType
    {
        [Rotation(LayerType.Second, LayerType.Second)]
        Middle,
        [Rotation(LayerType.First, LayerType.Second)]
        MiddleUp,
        [Rotation(LayerType.Third, LayerType.Second)]
        MiddleDown,
        [Rotation(LayerType.Second, LayerType.First)]
        LeftMiddle,
        [Rotation(LayerType.First, LayerType.First)]
        LeftUp,
        [Rotation(LayerType.Third, LayerType.First)]
        LeftDown,
        [Rotation(LayerType.Second, LayerType.Third)]
        RightMiddle,
        [Rotation(LayerType.First, LayerType.Third)]
        RightUp,
        [Rotation(LayerType.Third, LayerType.Third)]
        RightDown
    }
}