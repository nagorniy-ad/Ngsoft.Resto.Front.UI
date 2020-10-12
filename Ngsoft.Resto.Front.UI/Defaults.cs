using System.Windows;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal static class Defaults
    {
        internal static Thickness PluginWindowPadding => new Thickness(40, 20, 40, 20);
        internal static Thickness NotificationPadding => new Thickness(20);
        internal static SolidColorBrush ButtonPressed => new SolidColorBrush(color: Color.FromRgb(223, 227, 132));
    }
}
