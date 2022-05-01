using System;
using System.Windows.Input;

using SearchPictures.View;
using SearchPictures.ViewModel;


namespace SearchPictures.Commands
{
    public class FirstPageCommand : ICommand
    {
        private readonly SearchViewModel mySearchViewModel;

        public FirstPageCommand(SearchViewModel searchViewModel)
        {
            mySearchViewModel = searchViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return mySearchViewModel.CurrentPageIndex != 0;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            mySearchViewModel.ShowFirstPage();
        }
    }
}