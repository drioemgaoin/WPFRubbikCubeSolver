namespace RubiksCube.Entity
{
    public class Cube
    {
        public double[,] Rotations { get; set; }
         
        public Face FrontFace { get; set; }
        public Face LeftFace { get; set; }
        public Face RightFace { get; set; }
        public Face BottomFace { get; set; }
        public Face TopFace { get; set; }
        public Face BackFace { get; set; }
    }
}