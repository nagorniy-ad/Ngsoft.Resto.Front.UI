using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Ngsoft.Resto.Front.UI
{
    internal abstract class ChooserButtonBase : Label
    {
        internal ChooserButtonBase()
        {
            FontSize = 16;
            Background = Brushes.White;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            Margin = new Thickness(1);
            Padding = Defaults.PluginWindowPadding;
            MouseLeftButtonDown += (sender, e) => Background = Defaults.ButtonPressed;
        }
    }
}
