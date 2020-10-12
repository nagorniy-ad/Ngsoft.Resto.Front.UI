using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class NotificationButton : Label
    {
        internal NotificationButton(string text, Color foreground, Notification notification, Action action = null)
        {
            Content = text;
            FontSize = 16;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            Padding = Defaults.NotificationPadding;
            Background = Brushes.Transparent;
            Foreground = new SolidColorBrush(foreground);
            BorderThickness = new Thickness(0);
            MouseLeftButtonDown += (sender, e) => Background = Defaults.ButtonPressed;
            MouseLeftButtonUp += (sender, e) =>
            {
                notification.Close();
                action?.Invoke();
            };
        }
    }
}
