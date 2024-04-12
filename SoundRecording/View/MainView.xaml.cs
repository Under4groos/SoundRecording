using SoundRecording.ViewModel;
using System.Windows.Controls;

namespace SoundRecording.View
{

    public partial class MainView : UserControl
    {
        private ViewModel_MainView viewModel_MainView = new ViewModel_MainView();
        public MainView()
        {
            InitializeComponent();
            this.DataContext = viewModel_MainView;

            this.Loaded += MainView_Loaded;




        }

        private void MainView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                viewModel_MainView.Add(new Model.ModelSound()
                {
                    Name = i.ToString(),
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                });
            }
        }
    }
}
