using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using SearchPictures.Annotations;
using SearchPictures.Commands;
using SearchPictures.DAL;
using SearchPictures.Model;


namespace SearchPictures.ViewModel
{
    public class SearchViewModel : ISearchViewModel, INotifyPropertyChanged
    {
        private readonly IImagesSourceStrategy mySearchModel;
        private IList<ImageData> myImageData;
        private IList<ImageData> myAllImages;
        private ICommand mySearchButtonClicked;
        private ICommand myPreviousButtonClicked;
        private ICommand myNextButtonClicked;
        private ICommand myFirstButtonClicked;
        private ICommand myLastButtonClicked;

        private const int ItemsPerPage = 20;
        private int myItemCount;
        private int myCurrentPageIndex;
        private int myTotalPages;
        private int myCurrentPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchViewModel()
        {
            mySearchModel = new FlickrImagesStrategy();
            mySearchModel.UpdateImageData += UpdateImageData;
        }

        public string SearchText { get; set; }

        public IList<ImageData> AllImages { 
            get => myAllImages;
            set
            {
                myAllImages = value;
                myItemCount = AllImages.Count;
                CalculateTotalPages();
            }
        }

        /// <see cref="ISearchViewModel.Images"/>
        public IList<ImageData> Images
        {
            get => myImageData;
            set
            {
                myImageData = value;
                OnPropertyChanged();
            }
        }

        public int CurrentPageIndex
        {
            get => myCurrentPageIndex;
            set
            {
                myCurrentPageIndex = value;
                CurrentPage = myCurrentPageIndex + 1;
            }
        }

        public int CurrentPage
        {
            get => myCurrentPage;
            set
            {
                myCurrentPage = value;
                OnPropertyChanged();
            }
        }

        public int TotalPages
        {
            get => myTotalPages;
            private set
            {
                myTotalPages = value;
                OnPropertyChanged();
            }
        }

        /// <see cref="ISearchViewModel.SearchButtonClickCommand"/>
        public ICommand SearchButtonClickCommand
        {
            get => mySearchButtonClicked ?? new RelayCommand(SearchButtonClicked, null);
            set => mySearchButtonClicked = value;
        }

        public ICommand PreviousButtonClickedCommand
        {
            get => myPreviousButtonClicked ?? new RelayCommand(PreviousButtonClicked, null);
            set => myPreviousButtonClicked = value;
        }

        public ICommand NextButtonClickedCommand
        {
            get => myNextButtonClicked ?? new RelayCommand(NextButtonClicked, null);
            set => myNextButtonClicked = value;
        }

        public ICommand FirstButtonClickedCommand
        {
            get => myFirstButtonClicked ?? new RelayCommand(FirstButtonClicked, null);
            set => myFirstButtonClicked = value;
        }

        public ICommand LastButtonClickedCommand
        {
            get => myLastButtonClicked ?? new RelayCommand(LastButtonClicked, null);
            set => myLastButtonClicked = value;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateImageData(object sender, ImageDataEventArgs e)
        {
            AllImages = e.Images;
            CurrentPage = 1;
            SetImagesToDisplayPerPage(AllImages);
        }

        private void SetImagesToDisplayPerPage(IList<ImageData> allImages)
        {
            Images = allImages.Skip(CurrentPageIndex * ItemsPerPage).Take(ItemsPerPage).ToList();
        }

        private void SearchButtonClicked()
        {
            mySearchModel.GetDataFromSource(SearchText);
        }

        private void PreviousButtonClicked()
        {
            if (CurrentPageIndex != 0)
            {
                CurrentPageIndex--;
            }

            SetImagesToDisplayPerPage(AllImages);
        }

        private void NextButtonClicked()
        {
            if (CurrentPageIndex != TotalPages - 1)
            {
                CurrentPageIndex++;
            }

            SetImagesToDisplayPerPage(AllImages);
        }
        private void FirstButtonClicked()
        {
            CurrentPageIndex = 0;
            SetImagesToDisplayPerPage(AllImages);
        }

        private void LastButtonClicked()
        {
            CurrentPageIndex = TotalPages - 1;
            SetImagesToDisplayPerPage(AllImages);
        }

        private void CalculateTotalPages()
        {
            TotalPages = myItemCount % ItemsPerPage == 0 ? (myItemCount / ItemsPerPage) : (myItemCount / ItemsPerPage) + 1;
        }
    }
}