using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Ngsoft.Resto.Front.UI
{
    internal class PluginWindow : PluginWindowBase
    {
        internal PluginWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Background = Brushes.Transparent;
            AllowsTransparency = true;
            MinWidth = SystemParameters.PrimaryScreenWidth * 0.3;
            MaxWidth = SystemParameters.PrimaryScreenWidth * 0.9;
            MaxHeight = SystemParameters.PrimaryScreenHeight * 0.9;
        }

        internal void Build(string title, UIElement body, List<FooterButton> buttons)
        {
            var root = new DockPanel
            {
                Background = new SolidColorBrush(color: Color.FromRgb(63, 65, 64)),
                Margin = new Thickness(20)
            };
            root.Effect = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = -90,
                ShadowDepth = 2,
                BlurRadius = 15
            };
            var header = new Header(title);
            var footer = new Footer(buttons);
            DockPanel.SetDock(header, Dock.Top);
            DockPanel.SetDock(footer, Dock.Bottom);
            root.Children.Add(header);
            root.Children.Add(footer);
            root.Children.Add(body);
            Content = root;
        }
    }
}
