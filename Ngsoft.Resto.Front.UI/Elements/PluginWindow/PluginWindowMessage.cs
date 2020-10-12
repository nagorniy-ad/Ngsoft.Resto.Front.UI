using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class PluginWindowMessage : TextBlock
    {
        internal PluginWindowMessage(string text)
        {
            Text = text;
            FontSize = 18;
            Foreground = Brushes.White;
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            TextWrapping = TextWrapping.Wrap;
            TextAlignment = TextAlignment.Center;
            Margin = new Thickness(2);
            Padding = Defaults.PluginWindowPadding;
        }
    }
}
