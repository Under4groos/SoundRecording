using NAudio.CoreAudioApi;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SoundRecording.View
{
    /// <summary>
    /// Логика взаимодействия для MMDeviceControl.xaml
    /// </summary>
    public partial class MMDeviceControl : UserControl
    {
        public MMDeviceControl()
        {
            InitializeComponent();

            //if (Global.MMDeviceControls.Contains(this))
            //{
            //    Global.MMDeviceControls.Insert(Global.MMDeviceControls.IndexOf(this), this);
            //}
            //{
            //    Global.MMDeviceControls.Add(this);
            //}

        }
        public MMDevice MMDevice
        {
            get { return (MMDevice)GetValue(MMDeviceProperty); }
            set { SetValue(MMDeviceProperty, value); }
        }
        public static readonly DependencyProperty MMDeviceProperty =
          DependencyProperty.Register("MMDevice", typeof(MMDevice), typeof(MMDeviceControl));

        public string MMDeviceName
        {
            get { return (string)GetValue(MMDeviceNameProperty); }
            set { SetValue(MMDeviceNameProperty, value); }
        }
        public static readonly DependencyProperty MMDeviceNameProperty =
          DependencyProperty.Register("MMDeviceName", typeof(string), typeof(MMDeviceControl));



        public bool Select
        {
            get { return (bool)GetValue(SelectProperty); }
            set { SetValue(SelectProperty, value); }
        }
        public static readonly DependencyProperty SelectProperty =
          DependencyProperty.Register("Select", typeof(bool), typeof(MMDeviceControl));




        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            Select = !Select;

        }
    }
}
