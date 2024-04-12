using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoundRecording.ViewModel
{

    public class ViewModel_Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
