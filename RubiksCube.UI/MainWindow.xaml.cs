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
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.L)
            {
                RubiksCube.RotateLeftLayerUp();
            }
            else if (key == Key.L)
            {
                RubiksCube.RotateLeftLayerDown();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.R)
            {
                RubiksCube.RotateRightLayerUp();
            }
            else if (key == Key.R)
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
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.F)
            {
                RubiksCube.RotateFrontLayerLeft();
            }
            else if (key == Key.F)
            {
                RubiksCube.RotateFrontLayerRight();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.B)
            {
                RubiksCube.RotateBackLayerLeft();
            }
            else if (key == Key.B)
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
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.U)
            {
                RubiksCube.RotateUpLayerLeft();
            }
            else if (key == Key.U)
            {
                RubiksCube.RotateUpLayerRight();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.D)
            {
                RubiksCube.RotateDownLayerLeft();
            }
            else if (key == Key.D)
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