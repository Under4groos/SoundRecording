using NAudio.CoreAudioApi;
using SoundRecording.Model;
using System.Collections.ObjectModel;

namespace SoundRecording.ViewModel
{
    public class ViewModel_MainView : ViewModel_Base
    {


        private ObservableCollection<ModelSound> _Sounds = new ObservableCollection<ModelSound>();
        public ObservableCollection<ModelSound> Sounds
        {
            get
            {
                return _Sounds;
            }
            set
            {
                _Sounds = value;
                OnPropertyChanged(nameof(Sounds));
            }
        }

        private ObservableCollection<MMDevice> mDevices = new ObservableCollection<MMDevice>();

        public ObservableCollection<MMDevice> Devices
        {
            get
            {
                return mDevices;
            }
            set
            {
                mDevices = value;
                OnPropertyChanged(nameof(MMDevice));
            }
        }


        public void Add(ModelSound modelSound)
        {
            if (Sounds.Contains(modelSound))
            {

                Sounds.Insert(Sounds.IndexOf(modelSound), modelSound);
            }
            else
            {
                Sounds.Add(modelSound);
            }
        }
        public void Add(MMDevice modelSound)
        {
            if (Devices.Contains(modelSound))
            {

                Devices.Insert(Devices.IndexOf(modelSound), modelSound);
            }
            else
            {
                Devices.Add(modelSound);
            }
            OnPropertyChanged(nameof(MMDevice));
        }







    }
}
