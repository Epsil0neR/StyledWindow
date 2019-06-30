using System.Windows;
using System.Windows.Input;

namespace StyledWindow.Resources.Styles
{
    public partial class WindowStyle
    {
        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            if (!(sender is System.Windows.Window w))
                return;


            w.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
            w.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
            w.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
            w.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
        }

        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = sender is System.Windows.Window w &&
                           (w.ResizeMode == ResizeMode.CanResize ||
                            w.ResizeMode == ResizeMode.CanResizeWithGrip);
        }

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = sender is System.Windows.Window w && w.ResizeMode != ResizeMode.NoResize;
        }

        private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is System.Windows.Window w)
                SystemCommands.CloseWindow(w);
        }

        private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is System.Windows.Window w)
                SystemCommands.MaximizeWindow(w);
        }

        private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is System.Windows.Window w)
                SystemCommands.MinimizeWindow(w);
        }

        private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
        {
            if (target is System.Windows.Window w)
                SystemCommands.RestoreWindow(w);
        }
    }
}
