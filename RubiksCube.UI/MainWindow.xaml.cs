using System.Windows;
using System.Windows.Input;
using RubiksCube.Core.Model;

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
            if(Keyboard.IsKeyDown(Key.NumPad9))
            {
                RubiksCube.RotateRowRight(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                RubiksCube.RotateRowLeft(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad6))
            {
                RubiksCube.RotateRowRight(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad4))
            {
                RubiksCube.RotateRowLeft(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad3))
            {
                RubiksCube.RotateRowRight(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad1))
            {
                RubiksCube.RotateRowLeft(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.Q))
            {
                RubiksCube.RotateColumnUp(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.Z))
            {
                RubiksCube.RotateColumnDown(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                RubiksCube.RotateColumnUp(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.X))
            {
                RubiksCube.RotateColumnDown(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.E))
            {
                RubiksCube.RotateColumnUp(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.C))
            {
                RubiksCube.RotateColumnDown(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.Left))
            {
                RubiksCube.RotateLeft();
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                RubiksCube.RotateRight();
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                RubiksCube.RotateUp();
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                RubiksCube.RotateDown();
            }
            else if (Keyboard.IsKeyDown(Key.M))
            {
                RubiksCube.MixUp();
            }
            else if (Keyboard.IsKeyDown(Key.R))
            {
                RubiksCube.Resolve();
            }
        }
    }
}
