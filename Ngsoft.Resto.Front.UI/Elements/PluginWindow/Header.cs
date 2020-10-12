using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class Header : Label
    {
        internal Header(string title)
        {
            Content = title;
            FontSize = 22;
            Foreground = Brushes.White;
            Background = new SolidColorBrush(Colors.Transparent);
            HorizontalContentAlignment = HorizontalAlignment.Center;
            Padding = Defaults.PluginWindowPadding;
        }
    }
}
