namespace SoundRecording.ViewModel
{
    internal class ViewModel_SoundPanel : ViewModel_Base
    {
        private string _name = "-null-";

        public string SoundName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(SoundName));
            }
        }
    }
}
