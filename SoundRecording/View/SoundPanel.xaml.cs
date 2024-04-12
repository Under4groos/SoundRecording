using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SoundRecording.View
{
    /// <summary>
    /// Логика взаимодействия для SoundPanel.xaml
    /// </summary>
    public partial class SoundPanel : UserControl
    {
        public Action<SoundPanel, bool> EventSelect;
        public SoundPanel()
        {
            InitializeComponent();

            if (Global.SoundPanels.Contains(this))
            {
                Global.SoundPanels.Insert(Global.SoundPanels.IndexOf(this), this);
            }
            {
                Global.SoundPanels.Add(this);
            }

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


        public bool Select
        {
            get { return (bool)GetValue(SelectProperty); }
            set { SetValue(SelectProperty, value); }
        }
        public static readonly DependencyProperty SelectProperty =
          DependencyProperty.Register("Select", typeof(bool), typeof(SoundPanel));




        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            Select = !Select;
            if (EventSelect != null)
                EventSelect(this, Select);

            foreach (SoundPanel item in Global.SoundPanels)
            {
                if (item == this)
                    continue;
                item.Select = false;
            }
        }
    }
}
