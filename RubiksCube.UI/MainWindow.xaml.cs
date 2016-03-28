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
                RubiksCube.RotateFaceLeft();
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                RubiksCube.RotateFaceRight();
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                RubiksCube.RotateFaceUp();
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                RubiksCube.RotateFaceDown();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                RubiksCube.RotateFirstYLayerCounterClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad1))
            {
                RubiksCube.RotateFirstYLayerClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad9))
            {
                RubiksCube.RotateThirdYLayerCounterClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad3))
            {
                RubiksCube.RotateThirdYLayerClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.Q))
            {
                RubiksCube.RotateFirstXLayerClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                RubiksCube.RotateFirstXLayerCounterClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                RubiksCube.RotateThirdXLayerClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                RubiksCube.RotateThirdXLayerCounterClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.E))
            {
                RubiksCube.RotateFirstZLayerCounterClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.R))
            {
                RubiksCube.RotateFirstZLayerClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.M))
            {
                RubiksCube.MixUp();
            }
        }
    }
}