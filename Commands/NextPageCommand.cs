using System;
using System.Windows.Input;

using SearchPictures.View;


namespace SearchPictures.Commands
{
    public class NextPageCommand : ICommand
    {
        private readonly PaginationViewModel myPaginationViewModel;

        public NextPageCommand(PaginationViewModel paginationViewModel)
        {
            myPaginationViewModel = paginationViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return myPaginationViewModel.TotalPages - 1 > myPaginationViewModel.CurrentPageIndex;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            myPaginationViewModel.ShowNextPage();
        }
    }
}