using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class NotificationMessage : Label
    {
        internal NotificationMessage(string message, Color foreground)
        {
            var text = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            Content = text;
            FontSize = 14;
            HorizontalContentAlignment = HorizontalAlignment.Left;
            VerticalContentAlignment = VerticalAlignment.Center;
            Padding = Defaults.NotificationPadding;
            Background = Brushes.Transparent;
            Foreground = new SolidColorBrush(foreground);
            BorderThickness = new Thickness(0);
        }
    }
}
