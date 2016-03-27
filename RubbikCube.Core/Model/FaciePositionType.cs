namespace RubiksCube.Core.Model
{
    public enum FaciePositionType
    {
        None = 0,
        [Rotation(CubeLayerType.Second, CubeLayerType.Second)]
        Middle,
        [Rotation(CubeLayerType.First, CubeLayerType.Second)]
        MiddleTop,
        [Rotation(CubeLayerType.Third, CubeLayerType.Second)]
        MiddleBottom,
        [Rotation(CubeLayerType.Second, CubeLayerType.First)]
        LeftMiddle,
        [Rotation(CubeLayerType.First, CubeLayerType.First)]
        LeftTop,
        [Rotation(CubeLayerType.Third, CubeLayerType.First)]
        LeftBottom,
        [Rotation(CubeLayerType.Second, CubeLayerType.Third)]
        RightMiddle,
        [Rotation(CubeLayerType.First, CubeLayerType.Third)]
        RightTop,
        [Rotation(CubeLayerType.Third, CubeLayerType.Third)]
        RightBottom
    }
}