using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace Ngsoft.Resto.Front.UI
{
    public class PluginViewManager
    {
        public void ShowOkPopup(string title, string message)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var thread = new Thread(() => ShowOkPluginWindow(title, body: new PluginWindowMessage(message)));
            Run(thread);
        }

        public void ShowOkProperties(string title, IDictionary<string, string> properties)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            var thread = new Thread(() => ShowOkPluginWindow(title, body: new Properties(properties)));
            Run(thread);
        }

        public void ShowErrorPopup(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var thread = new Thread(() => ShowErrorPluginWindow(body: new PluginWindowMessage(message)));
            Run(thread);
        }

        public void ShowErrorProperties(IDictionary<string, string> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            var thread = new Thread(() => ShowErrorPluginWindow(body: new Properties(properties)));
            Run(thread);
        }

        public bool ShowYesNoPopup(string title, string message)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var result = false;
            var thread = new Thread(() =>
            {
                result = ShowYesNoWindow(title, body: new PluginWindowMessage(message));
            });
            Run(thread);
            return result;
        }

        public bool ShowYesNoProperties(string title, IDictionary<string, string> properties)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            var result = false;
            var thread = new Thread(() =>
            {
                result = ShowYesNoWindow(title, body: new Properties(properties));
            });
            Run(thread);
            return result;
        }

        public T ShowChooserPopup<T>(string title, IEnumerable<T> items, Func<T, string> namingFunc)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            if (namingFunc == null)
            {
                throw new ArgumentNullException(nameof(namingFunc));
            }

            T result = default;
            var thread = new Thread(() =>
            {
                var window = new PluginWindow();
                var chooser = new Chooser<T>(
                    items: items.Select(i =>
                    {
                        var chooserItem = new ChooserItem<T>(i, namingFunc, window);
                        chooserItem.MouseLeftButtonUp += (sender, e) => result = chooserItem.Item;
                        return chooserItem;
                    }).ToList());
                var cancelButton = new FooterButton("Отмена", window);
                window.Build(
                    title,
                    body: chooser,
                    buttons: new List<FooterButton> { cancelButton });
                window.ShowDialog();
            });
            Run(thread);
            return result;
        }

        public void ShowNotification(string message, Action action, Color background, Color foreground, bool waitForExit = false, int? closeTimeout = 10000, Action closeAction = null)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (background == null)
            {
                throw new ArgumentNullException(nameof(background));
            }
            if (foreground == null)
            {
                throw new ArgumentNullException(nameof(foreground));
            }
            if (closeTimeout <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(closeTimeout), "Close timeout cannot be negative or zero.");
            }

            var thread = new Thread(() =>
            {
                var notification = new Notification(message, action, background, foreground, closeAction);
                using (var timer = new Timer(state => notification.Dispatcher.Invoke(notification.Close), state: null, dueTime: closeTimeout == null ? Timeout.Infinite : (int)closeTimeout, period: Timeout.Infinite))
                {
                    notification.Closing += (sender, args) =>
                    {
                        timer.Change(Timeout.Infinite, Timeout.Infinite);
                    };
                    notification.ShowDialog();
                }
            });
            Run(thread, waitForExit);
        }

        #region private

        private void ShowOkPluginWindow(string title, UIElement body)
        {
            var window = new PluginWindow();
            var okButton = new FooterButton("OK", window);
            window.Build(
                title,
                body,
                buttons: new List<FooterButton> { okButton });
            window.ShowDialog();
        }

        private void ShowErrorPluginWindow(UIElement body)
        {
            var window = new PluginWindow();
            var closeButton = new FooterButton("Закрыть", window);
            window.Build(
                title: "Ошибка",
                body,
                buttons: new List<FooterButton> { closeButton });
            window.ShowDialog();
        }

        private bool ShowYesNoWindow(string title, UIElement body)
        {
            var result = false;
            var window = new PluginWindow();
            var yesButton = new FooterButton("Да", window);
            var noButton = new FooterButton("Нет", window);
            yesButton.MouseLeftButtonUp += (sender, e) => result = true;
            noButton.MouseLeftButtonUp += (sender, e) => result = false;
            window.Build(
                title,
                body,
                buttons: new List<FooterButton> { yesButton, noButton });
            window.ShowDialog();
            return result;
        }

        private void Run(Thread thread, bool waitForExit = true)
        {
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            if (waitForExit)
            {
                thread.Join();
            }
        }

        #endregion
    }
}
