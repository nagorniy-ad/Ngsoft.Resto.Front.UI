using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Ngsoft.Resto.Front.UI
{
    internal class Chooser<T> : UniformGrid
    {
        private readonly ICollection<ChooserItem<T>> _items;
        private const int TAKE_VALUE = 7;

        internal Chooser(ICollection<ChooserItem<T>> items)
        {
            _items = items;
            Margin = new Thickness(2, 2, 2, 20);
            if (items.Count <= 3)
            {
                Columns = 1;
            }
            Show(skipValue: 0);
        }

        private void Show(int skipValue)
        {
            if (skipValue > 0)
            {
                Children.Add(new ChooserPageButton<T>(
                    action: c =>
                    {
                        c.Children.Clear();
                        c.Show(skipValue: skipValue - TAKE_VALUE == 1 ? 0 : skipValue - TAKE_VALUE);
                    },
                    chooser: this,
                    text: "<"));
            }
            var selected = _items
                .Skip(skipValue)
                .Take(skipValue == 0 ? TAKE_VALUE + 1 : TAKE_VALUE);
            foreach (var item in selected)
            {
                Children.Add(item);
            }
            if (skipValue + TAKE_VALUE < _items.Count)
            {
                Children.Add(new ChooserPageButton<T>(
                    action: c =>
                    {
                        c.Children.Clear();
                        c.Show(skipValue: skipValue == 0 ? TAKE_VALUE + 1 : skipValue + TAKE_VALUE);
                    },
                    chooser: this,
                    text: ">"));
            }
        }
    }
}
