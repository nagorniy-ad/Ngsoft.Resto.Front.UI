using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class Footer : UniformGrid
    {
        internal Footer(IEnumerable<FooterButton> buttons)
        {
            var panel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            foreach (var button in buttons)
            {
                panel.Children.Add(button);
            }
            HorizontalAlignment = HorizontalAlignment.Stretch;
            Background = new SolidColorBrush(color: Color.FromRgb(32, 32, 32));
            Children.Add(panel);
        }
    }
}
