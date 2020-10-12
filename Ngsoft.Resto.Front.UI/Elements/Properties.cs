using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    internal class Properties : Grid
    {
        internal Properties(IDictionary<string, string> properties)
        {
            Margin = new Thickness(15);
            var propertyNameColumn = new ColumnDefinition
            {
                Width = new GridLength(0.4, GridUnitType.Star)
            };
            var propertyValueColumn = new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
            ColumnDefinitions.Add(propertyNameColumn);
            ColumnDefinitions.Add(propertyValueColumn);
            var propertyCount = 0;
            foreach (var property in properties)
            {
                var propertyName = new Label
                {
                    Content = new TextBlock
                    {
                        Text = property.Key,
                        TextAlignment = TextAlignment.Right,
                        FontSize = 16,
                        TextWrapping = TextWrapping.Wrap,
                        TextTrimming = TextTrimming.CharacterEllipsis
                    },
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 1, 0, 1),
                    Padding = new Thickness(10),
                    Background = new SolidColorBrush(color: Color.FromRgb(255, 218, 255)),
                    BorderThickness = new Thickness(0)
                };
                var propertyValue = new Label
                {
                    Content = new TextBlock
                    {
                        Text = property.Value,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 16,
                        TextWrapping = TextWrapping.Wrap,
                        TextTrimming = TextTrimming.CharacterEllipsis
                    },
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 1, 0, 1),
                    Padding = new Thickness(10),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(0)
                };
                var row = new RowDefinition();
                RowDefinitions.Add(row);
                SetColumn(propertyName, 0);
                SetColumn(propertyValue, 1);
                SetRow(propertyName, propertyCount);
                SetRow(propertyValue, propertyCount);
                Children.Add(propertyName);
                Children.Add(propertyValue);
                propertyCount++;
            }
        }
    }
}
