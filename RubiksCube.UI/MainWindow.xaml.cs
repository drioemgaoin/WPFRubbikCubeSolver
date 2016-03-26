using System.Windows;
using System.Windows.Input;

namespace RubiksCube.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            KeyDown += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                RubiksCube.RotateLeftWholeFace();
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                RubiksCube.RotateRightWholeFace();
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                RubiksCube.RotateUpWholeFace();
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                RubiksCube.RotateDownWholeFace();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                RubiksCube.RotateLeftFace();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad1))
            {
                RubiksCube.RotateLeftFaceBackward();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad9))
            {
                RubiksCube.RotateRightFace();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad3))
            {
                RubiksCube.RotateRightFaceBackward();
            }
            else if (Keyboard.IsKeyDown(Key.Q))
            {
                RubiksCube.RotateTopFaceBackward();
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                RubiksCube.RotateTopFace();
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                RubiksCube.RotateBottomFaceBackward();
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                RubiksCube.RotateBottomFace();
            }
            else if (Keyboard.IsKeyDown(Key.E))
            {
                RubiksCube.RotateForwardFaceBackward();
            }
            else if (Keyboard.IsKeyDown(Key.R))
            {
                RubiksCube.RotateForwardFace();
            }
            else if (Keyboard.IsKeyDown(Key.M))
            {
                RubiksCube.MixUp();
            }
        }
    }
}