using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using SearchPictures.Annotations;
using SearchPictures.Model;


namespace SearchPictures.ViewModel
{
    internal class SearchViewModel : ISearchViewModel, INotifyPropertyChanged
    {
        private ICommand mySearchButtonClicked;
        private readonly ISearchPicturesModel mySearchModel;
        private IList<FlikarSearch> myImageData;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchText { get; set; }

        public IList<FlikarSearch> ImageData
        {
            get => myImageData;
            set
            {
                myImageData = value;
                OnPropertyChanged();
            }
        }

        public SearchViewModel()
        {
            mySearchModel = new SearchPicturesModel();
            mySearchModel.UpdateImageData += UpdateImageData;
        }

        public ICommand SearchButtonClickCommand
        {
            get => mySearchButtonClicked ?? new RelayCommand(SearchButtonClicked, null);
            set => mySearchButtonClicked = value;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateImageData(object sender, ImageDataEventArgs e)
        {
            ImageData = e.Images;
        }

        private void SearchButtonClicked()
        {
            mySearchModel.SearchButtonClick(SearchText);
        }
    }
}