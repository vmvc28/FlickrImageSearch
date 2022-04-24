using System;
using System.Threading.Tasks;


namespace SearchPictures.Model
{
    public interface ISearchPicturesModel
    {
        event EventHandler<ImageDataEventArgs> UpdateImageData;

        Task SearchButtonClick(string searchString);
    }
}