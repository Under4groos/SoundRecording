using System.Windows;
using System.Windows.Controls;

namespace SoundRecording.View
{
    /// <summary>
    /// Логика взаимодействия для SoundPanel.xaml
    /// </summary>
    public partial class SoundPanel : UserControl
    {

        public SoundPanel()
        {
            InitializeComponent();

        }
        public string SoundName
        {
            get { return (string)GetValue(SoundNameProperty); }
            set { SetValue(SoundNameProperty, value); }
        }
        public static readonly DependencyProperty SoundNameProperty =
          DependencyProperty.Register("SoundName", typeof(string), typeof(SoundPanel));

        public string StringDateTime
        {
            get { return (string)GetValue(StringDateTimeProperty); }
            set { SetValue(StringDateTimeProperty, value); }
        }
        public static readonly DependencyProperty StringDateTimeProperty =
          DependencyProperty.Register("StringDateTime", typeof(string), typeof(SoundPanel));

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly DependencyProperty TimeProperty =
          DependencyProperty.Register("Time", typeof(string), typeof(SoundPanel));
    }
}
