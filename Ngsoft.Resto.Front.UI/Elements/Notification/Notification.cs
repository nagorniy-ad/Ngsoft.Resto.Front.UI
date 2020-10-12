using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class Notification : PluginWindowBase
    {
        internal Notification(string message, Action action, Color background, Color foreground, Action closeAction = null)
        {
            WindowStartupLocation = WindowStartupLocation.Manual;
            Background = Brushes.Transparent;
            AllowsTransparency = true;
            MinWidth = SystemParameters.PrimaryScreenWidth * 0.3;
            MaxWidth = SystemParameters.PrimaryScreenWidth * 0.9;
            MaxHeight = SystemParameters.PrimaryScreenHeight * 0.9;
            Loaded += (sender, args) =>
            {
                Left = SystemParameters.WorkArea.Right - Width + 1;
                Top = SystemParameters.WorkArea.Top + 20;
            };

            var root = new DockPanel
            {
                Background = new SolidColorBrush(background)
            };
            var notificationMessage = new NotificationMessage(message, foreground);
            DockPanel.SetDock(notificationMessage, Dock.Left);
            var actionButton = new NotificationButton("\u2192", foreground, this, action)
            {
                FontSize = 18
            };
            DockPanel.SetDock(actionButton, Dock.Right);
            var closeButton = new NotificationButton("\u2573", foreground, this, closeAction)
            {
                FontSize = 18
            };
            DockPanel.SetDock(closeButton, Dock.Right);
            root.Children.Add(closeButton);
            root.Children.Add(actionButton);
            root.Children.Add(notificationMessage);
            Content = root;
        }
    }
}
