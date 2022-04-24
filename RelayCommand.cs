using System;
using System.Windows.Input;


namespace SearchPictures
{
    public class RelayCommand : ICommand
    {
        private readonly Action myExecute;
        private readonly Func<bool> myCanExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            myExecute = execute;
            myCanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return myCanExecute == null || myCanExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            myExecute();
        }
    }
}