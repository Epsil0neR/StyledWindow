using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;

namespace StyledWindow.Styles
{
    public partial class WindowStyle
    {
        private static readonly List<(Window window, List<CommandBinding> commands)> WindowsData = new List<(Window window, List<CommandBinding> commands)>();

        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            if (!(sender is Window w))
                return;

            var commands = new List<CommandBinding>()
            {
                new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow),
                new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow),
                new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow),
                new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow)
            };

            w.CommandBindings.AddRange(commands);

            WindowsData.Add((w, commands));
        }

        private void EventSetter_OffHandler(object sender, RoutedEventArgs e)
        {
            if (!(sender is Window w))
                return;

            var data = WindowsData.FirstOrDefault(x => ReferenceEquals(x.window, w));
            if (data.window == null)
                return;

            foreach (var command in data.commands)
                w.CommandBindings.Remove(command);

            WindowsData.Remove(data);
        }

        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = sender is Window w &&
                           (w.ResizeMode == ResizeMode.CanResize ||
                            w.ResizeMode == ResizeMode.CanResizeWithGrip);
        }

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = sender is Window w && w.ResizeMode != ResizeMode.NoResize;
        }

        private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is Window w)
                SystemCommands.CloseWindow(w);
        }

        private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is Window w)
                SystemCommands.MaximizeWindow(w);
        }

        private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is Window w)
                SystemCommands.MinimizeWindow(w);
        }

        private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is Window w)
                SystemCommands.RestoreWindow(w);
        }

        private void HeaderBackground_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is System.Windows.Shapes.Rectangle rectangle)
            {
                //1. Find window
                var window = Window.GetWindow(rectangle);

                if (window == null)
                    return;

                var chrome = WindowChrome.GetWindowChrome(window);
                if (chrome != null)
                    chrome.CaptionHeight = rectangle.ActualHeight;
            }
        }
    }
}
