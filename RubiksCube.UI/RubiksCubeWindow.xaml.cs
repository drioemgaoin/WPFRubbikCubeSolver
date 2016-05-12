using System.Windows;
using System.Windows.Input;
using RubiksCube.Core;

namespace RubiksCube.UI
{
    public partial class RubiksCubeWindow : Window
    {
        public RubiksCubeWindow()
        {
            InitializeComponent();

            KeyDown += OnKeyDown;
            MouseLeftButtonDown += (o, e) => DragMove();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (TryHandleWholeCubeRotation(e.Key))
            {
                return;
            }

            if (TryHandleYAxisFaceRotation(e.Key))
            {
                return;
            }

            if (TryHandleXAxisFaceRotation(e.Key))
            {
                return;
            }

            if (TryHandleZAxisFaceRotation(e.Key))
            {
                return;
            }

            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (e.Key == Key.M)
                {   
                    Cube.MixUp();
                }
                else if(e.Key == Key.S)
                {
                    Cube.Solve();
                }
            }
        }

        private bool TryHandleXAxisFaceRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.L)
            {
                Cube.RotateLeftFaceCounterClockwise();
            }
            else if (key == Key.L)
            {
                Cube.RotateLeftFaceClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.R)
            {
                Cube.RotateRightFaceCounterClockwise();
            }
            else if (key == Key.R)
            {
                Cube.RotateRightFaceClockwise();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleZAxisFaceRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.F)
            {
                Cube.RotateFrontFaceCounterClockwise();
            }
            else if (key == Key.F)
            {
                Cube.RotateFrontFaceClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.B)
            {
                Cube.RotateBackFaceCounterClockwise();
            }
            else if (key == Key.B)
            {
                Cube.RotateBackFaceClockwise();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleYAxisFaceRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.U)
            {
                Cube.RotateUpFaceCounterClockwise();
            }
            else if (key == Key.U)
            {
                Cube.RotateUpFaceClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.D)
            {
                Cube.RotateDownFaceCounterClockwise();
            }
            else if (key == Key.D)
            {
                Cube.RotateDownFaceClockwise();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleWholeCubeRotation(Key key)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.Y)
            {
                Cube.RotateCubeOnYAxisCounterClockwise();
            }
            else if (key == Key.Y)
            {
                Cube.RotateCubeOnYAxisClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.X)
            {
                Cube.RotateCubeOnXAxisCounterClockwise();
            }
            else if (key == Key.X)
            {
                Cube.RotateCubeOnXAxisClockwise();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && key == Key.Z)
            {
                Cube.RotateCubeOnZAxisCounterClockwise();
            }
            else if (key == Key.Z)
            {
                Cube.RotateCubeOnZAxisClockwise();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}