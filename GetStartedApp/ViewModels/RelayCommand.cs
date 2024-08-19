#pragma warning disable CS0067

using System;
using System.Windows.Input;

namespace GetStartedApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        public void Execute(object? parameter) => _execute();

        // No need for CommandManager in Avalonia
        public event EventHandler? CanExecuteChanged;
    }
}

#pragma warning restore CS0067

