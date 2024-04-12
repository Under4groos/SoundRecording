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
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.UseDarkMode(true);
        }
    }
}