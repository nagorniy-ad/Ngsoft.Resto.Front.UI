using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class FooterButton : Label
    {
        internal FooterButton(string text, PluginWindow window)
        {
            Content = text;
            FontSize = 20;
            Foreground = Brushes.White;
            Background = new SolidColorBrush(Colors.Transparent);
            HorizontalContentAlignment = HorizontalAlignment.Center;
            Padding = Defaults.PluginWindowPadding;
            MouseLeftButtonDown += (sender, e) => Background = Defaults.ButtonPressed;
            MouseLeftButtonUp += (sender, e) => window.Close();
        }
    }
}
