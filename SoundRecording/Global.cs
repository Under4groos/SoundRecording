using SoundRecording.View;
using System.Collections.ObjectModel;

namespace SoundRecording
{
    public static class Global
    {
        public static ObservableCollection<SoundPanel> SoundPanels = new ObservableCollection<SoundPanel>();
    }
}
