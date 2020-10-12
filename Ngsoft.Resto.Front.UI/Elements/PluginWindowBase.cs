using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Ngsoft.Resto.Front.UI
{
    internal abstract class PluginWindowBase : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        internal PluginWindowBase()
        {
            Topmost = true;
            ShowInTaskbar = false;
            ShowActivated = true;
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.None;
            Loaded += (sender, args) =>
            {
                var parent = Process.GetProcessesByName("iikoFront.Net").FirstOrDefault();
                if (parent == null)
                {
                    return;
                }
                else
                {
                    SetParent(hWndChild: new WindowInteropHelper(this).Handle, hWndNewParent: parent.MainWindowHandle);
                }
            };
        }
    }
}
