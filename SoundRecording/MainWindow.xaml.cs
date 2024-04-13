using SoundRecording.Model;
using System.Windows;

namespace SoundRecording
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Window window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.Close();
        }
        private void MaximizeRestoreClick(object sender, RoutedEventArgs e)
        {
            Window window = (Window)((FrameworkElement)sender).TemplatedParent;
            if (window.WindowState == System.Windows.WindowState.Normal)
            {
                window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            Window window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.WindowState = System.Windows.WindowState.Minimized;
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.UseDarkMode(true);
        }
    }
}