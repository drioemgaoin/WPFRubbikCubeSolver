using System.Windows;
using System.Windows.Input;

namespace RubiksCube.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (TryHandleFaceRotations(e.Key))
            {
                return;
            }

            if (TryHandleYAxisRotation(e.Key))
            {
                return;
            }

            if (TryHandleXAxisRotation(e.Key))
            {
                return;
            }

            if (TryHandleZAxisRotation(e.Key))
            {
                return;
            }

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.M)
            {
                RubiksCube.MixUp();
            }
        }

        private bool TryHandleXAxisRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.Q))
            {
                RubiksCube.RotateLeftLayerUp();
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                RubiksCube.RotateLeftLayerDown();
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                RubiksCube.RotateRightLayerUp();
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                RubiksCube.RotateRightLayerDown();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleZAxisRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.E))
            {
                RubiksCube.RotateFrontLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.R))
            {
                RubiksCube.RotateFrontLayerRight();
            }
            else if (Keyboard.IsKeyDown(Key.T))
            {
                RubiksCube.RotateBackLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.Y))
            {
                RubiksCube.RotateBackLayerRight();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleYAxisRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                RubiksCube.RotateUpLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad1))
            {
                RubiksCube.RotateUpLayerRight();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad9))
            {
                RubiksCube.RotateDownLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad3))
            {
                RubiksCube.RotateDownLayerRight();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleFaceRotations(Key key)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.Y)
            {
                RubiksCube.RotateFaceLeft();
            }
            else if (key == Key.Y)
            {
                RubiksCube.RotateFaceRight();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.X)
            {
                RubiksCube.RotateFaceDown();
            }
            else if (key == Key.X)
            {
                RubiksCube.RotateFaceUp();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.Z)
            {
                RubiksCube.RotateUpFaceLeft();
            }
            else if (key == Key.Z)
            {
                RubiksCube.RotateUpFaceRight();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}