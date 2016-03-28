﻿using System.Windows;
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
            if (TryHandleFaceRotations())
            {
                return;
            }

            if (TryHandleYAxisRotation())
            {
                return;
            }

            if (TryHandleXAxisRotation())
            {
                return;
            }

            if (TryHandleZAxisRotation())
            {
                return;
            }

            if (Keyboard.IsKeyDown(Key.M))
            {
                RubiksCube.MixUp();
            }
        }

        private bool TryHandleXAxisRotation()
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

        private bool TryHandleZAxisRotation()
        {
            if (Keyboard.IsKeyDown(Key.E))
            {
                RubiksCube.RotateFrontLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.R))
            {
                RubiksCube.RotateFrontLayerRight();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleYAxisRotation()
        {
            if (Keyboard.IsKeyDown(Key.NumPad7))
            {
                RubiksCube.RotateTopLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad1))
            {
                RubiksCube.RotateTopLayerRight();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad9))
            {
                RubiksCube.RotateBottomLayerLeft();
            }
            else if (Keyboard.IsKeyDown(Key.NumPad3))
            {
                RubiksCube.RotateBottomLayerRight();
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool TryHandleFaceRotations()
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
            else
            {
                return false;
            }

            return true;
        }
    }
}