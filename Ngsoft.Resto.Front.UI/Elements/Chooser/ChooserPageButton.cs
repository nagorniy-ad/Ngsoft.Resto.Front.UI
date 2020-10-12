using System;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class ChooserPageButton<T> : ChooserButtonBase
    {
        internal ChooserPageButton(Action<Chooser<T>> action, Chooser<T> chooser, string text)
        {
            Content = text;
            Background = new SolidColorBrush(color: Color.FromRgb(153, 153, 153));
            Foreground = Brushes.White;
            MouseLeftButtonUp += (sender, e) => action?.Invoke(chooser);
        }
    }
}
