using System.Windows.Controls;

namespace SoundRecording.View
{
    internal class c_ItemsControl : ItemsControl
    {

        protected override bool IsItemItsOwnContainerOverride(object item)
        {



            return false;
        }
    }
}
