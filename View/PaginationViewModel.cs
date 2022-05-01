using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

using SearchPictures.Annotations;
using SearchPictures.Commands;
using SearchPictures.Model;


namespace SearchPictures.View
{
    public class PaginationViewModel : INotifyPropertyChanged
    {
        private readonly int myItemsPerPage = 20;
        private readonly int myItemsCount;
        private int myCurrentPageIndex;
        private int myTotalPages;
        private readonly ISearchPicturesModel mySearchModel;

        public ICommand PreviousCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand FirstCommand { get; }
        public ICommand LastCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public PaginationViewModel()
        {
            //populateList();

            //ViewList = new CollectionViewSource();
            //ViewList = viewList;
            //ViewList.Source = PeopleList;
            //ViewList.Filter += new FilterEventHandler(ViewFilter);

            CurrentPageIndex = 0;
            //myItemsCount = peopleList.Count;
            //myItemsCount = totalCount;
            CalculateTotalPages();

            NextCommand = new NextPageCommand(this);
            PreviousCommand = new PreviousPageCommand(this);
            FirstCommand = new FirstPageCommand(this);
            LastCommand = new LastPageCommand(this);
        }

        public int CurrentPageIndex
        {
            get => myCurrentPageIndex;
            set
            {
                myCurrentPageIndex = value;
                OnPropertyChanged();
            }
        }

        public int CurrentPage => myCurrentPageIndex + 1;
        
        public int TotalPages
        {
            get => myTotalPages;
            private set
            {
                myTotalPages = value;
                OnPropertyChanged();
            }
        }

        public CollectionViewSource ViewList { get; set; }
        //private ObservableCollection<Person> peopleList = new ObservableCollection<Person>();

        //public ReadOnlyObservableCollection<Person> PeopleList
        //{
        //    get { return new ReadOnlyObservableCollection<Person>(peopleList); }
        //}

        public void ShowNextPage()
        {
            CurrentPageIndex++;
            mySearchModel.GetDataFromSource("dog", CurrentPageIndex);
            //ViewList.View.Refresh();
        }

        public void ShowPreviousPage()
        {
            CurrentPageIndex--;
            //ViewList.View.Refresh();
        }

        public void ShowFirstPage()
        {
            CurrentPageIndex = 0;
            //ViewList.View.Refresh();
        }

        public void ShowLastPage()
        {
            CurrentPageIndex = TotalPages - 1;
            //ViewList.View.Refresh();
        }

        public void ViewFilter(object sender, FilterEventArgs e)
        {
            
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateTotalPages()
        {
            if (myItemsCount % myItemsPerPage == 0)
            {
                TotalPages = (myItemsCount / myItemsPerPage);
            }
            else
            {
                TotalPages = (myItemsCount / myItemsPerPage) + 1;
            }
        }
    }
}