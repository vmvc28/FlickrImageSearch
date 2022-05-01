using System;
using System.Windows.Input;

using SearchPictures.View;


namespace SearchPictures.Commands
{
    public class LastPageCommand : ICommand
    {
        private readonly PaginationViewModel myPaginationViewModel;

        public LastPageCommand(PaginationViewModel paginationViewModel)
        {
            myPaginationViewModel = paginationViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return myPaginationViewModel.CurrentPage != myPaginationViewModel.TotalPages;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            myPaginationViewModel.ShowLastPage();
        }
    }
}