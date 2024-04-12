using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace SoundRecording.Model
{
    public static class WindowTheme
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public static bool UseDarkMode(this Window window, bool enabled)
        {
            HwndSource source = (HwndSource)PresentationSource.FromVisual(window);
            if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763))
            {
                int attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(source.Handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }
    }
}
