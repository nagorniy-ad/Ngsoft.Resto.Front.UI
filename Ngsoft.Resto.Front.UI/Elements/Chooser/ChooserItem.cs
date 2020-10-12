using System;
using System.Windows;
using System.Windows.Controls;

namespace Ngsoft.Resto.Front.UI
{
    internal class ChooserItem<T> : ChooserButtonBase
    {
        internal T Item { get; }

        internal ChooserItem(T item, Func<T, string> namingFunc, PluginWindow window)
        {
            Item = item;
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            Content = new TextBlock
            {
                Text = namingFunc.Invoke(item),
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            MouseLeftButtonUp += (sender, e) => window.Close();
        }
    }
}
