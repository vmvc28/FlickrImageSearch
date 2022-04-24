using System.Collections.Generic;
using System.Windows.Input;

using SearchPictures.Model;


namespace SearchPictures.ViewModel
{
    public interface ISearchViewModel
    {
        IList<FlikarSearch> ImageData { get; set; }
        ICommand SearchButtonClickCommand { get; set; }
        string SearchText { get; set; }
    }
}