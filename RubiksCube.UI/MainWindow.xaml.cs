using System.Windows;
using System.Windows.Input;

namespace WpfApplication
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
            switch (e.Key)
            {
                case Key.M:
                    RubbikCube.RotateRowRight();
                    break;
                case Key.K:
                    RubbikCube.RotateRowLeft();
                    break;
                case Key.O:
                    RubbikCube.RotateColumnUp();
                    break;
                case Key.L:
                    RubbikCube.RotateColumnDown();
                    break;
                case Key.Left:
                    RubbikCube.RotateLeft();
                    break;
                case Key.Right:
                    RubbikCube.RotateRight();
                    break;
                case Key.Up:
                    RubbikCube.RotateUp();
                    break;
                case Key.Down:
                    RubbikCube.RotateDown();
                    break;
            }
        }
    }
}
