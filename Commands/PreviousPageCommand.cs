using System;
using System.Windows.Input;

using SearchPictures.View;


namespace SearchPictures.Commands
{
    public class PreviousPageCommand : ICommand
    {
        private readonly PaginationViewModel myPaginationViewModel;

        public PreviousPageCommand(PaginationViewModel paginationViewModel)
        {
            myPaginationViewModel = paginationViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return myPaginationViewModel.CurrentPageIndex != 0;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            myPaginationViewModel.ShowPreviousPage();
        }
    }
}