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
    }
}
