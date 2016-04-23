namespace RubiksCube.Core.Model
{
    public enum FaciePositionType
    {
        [Rotation(LayerType.First, LayerType.First)]
        LeftUp = 1,
        [Rotation(LayerType.First, LayerType.Second)]
        MiddleUp,
        [Rotation(LayerType.First, LayerType.Third)]
        RightUp,
        [Rotation(LayerType.Second, LayerType.First)]
        LeftMiddle,
        [Rotation(LayerType.Second, LayerType.Second)]
        Center,
        [Rotation(LayerType.Second, LayerType.Third)]
        RightMiddle,
        [Rotation(LayerType.Third, LayerType.First)]
        LeftDown,
        [Rotation(LayerType.Third, LayerType.Second)]
        MiddleDown,
        [Rotation(LayerType.Third, LayerType.Third)]
        RightDown
    }
}