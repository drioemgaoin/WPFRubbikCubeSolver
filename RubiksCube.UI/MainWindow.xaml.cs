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
                RubbikCube.RotateRowRight(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                RubbikCube.RotateRowLeft(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad6))
            {
                RubbikCube.RotateRowRight(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad4))
            {
                RubbikCube.RotateRowLeft(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad3))
            {
                RubbikCube.RotateRowRight(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.NumPad1))
            {
                RubbikCube.RotateRowLeft(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.Q))
            {
                RubbikCube.RotateColumnUp(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.Z))
            {
                RubbikCube.RotateColumnDown(RotationType.First);
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                RubbikCube.RotateColumnUp(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.X))
            {
                RubbikCube.RotateColumnDown(RotationType.Second);
            }
            else if (Keyboard.IsKeyDown(Key.E))
            {
                RubbikCube.RotateColumnUp(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.C))
            {
                RubbikCube.RotateColumnDown(RotationType.Third);
            }
            else if (Keyboard.IsKeyDown(Key.Left))
            {
                RubbikCube.RotateLeft();
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                RubbikCube.RotateRight();
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                RubbikCube.RotateUp();
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                RubbikCube.RotateDown();
            }
        }
    }
}
