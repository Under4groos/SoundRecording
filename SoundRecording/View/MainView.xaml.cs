using NAudio.CoreAudioApi;
using NAudio.Wave;
using SoundRecording.Model;
using SoundRecording.ViewModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace SoundRecording.View
{

    public partial class MainView : UserControl
    {
        private ViewModel_MainView viewModel_MainView = new ViewModel_MainView();

        private WaveIn_AudioRecord waveIn_AudioRecord = new WaveIn_AudioRecord(
              0, (float data) =>
              {
                  Debug.WriteLine(data);
              }
          );

        public MainView()
        {
            InitializeComponent();
            this.DataContext = viewModel_MainView;

            this.Loaded += MainView_Loaded;




        }

        private void _refresh()
        {

            using (MMDeviceEnumerator Enumerator = new MMDeviceEnumerator())
            {
                viewModel_MainView.Devices.Clear();
                MMDeviceCollection list_ = Enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
                foreach (MMDevice? item in list_)
                {
                    viewModel_MainView.Add(item);
                }



            }
        }

        private void MainView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _refresh();

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

        private void Border_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _refresh();
        }

        private WaveInEvent waveIn;

        private void EventRecord(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (waveIn != null)
            {


                waveIn.StopRecording();








                return;
            }
            else
            {
                waveIn = new WaveInEvent()
                {
                    DeviceNumber = 0,
                    WaveFormat = new WaveFormat(44100, 1)
                };
            }
            WaveFileWriter waveFileWriter = new WaveFileWriter("output.wav", waveIn.WaveFormat);



            waveIn.DataAvailable += (sender, e) =>
            {
                waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
            };
            waveIn.RecordingStopped += (o, e) =>
            {
                waveFileWriter.Dispose();

                using (Mp3FileReader reader = new Mp3FileReader("output.wav"))
                {
                    using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
                    {
                        MediaFoundationEncoder.EncodeToMp3(pcmStream,
                           "output.mp3", 48000);
                    }
                }
            };




            waveIn.StartRecording();




        }
    }
}
