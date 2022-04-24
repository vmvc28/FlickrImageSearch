using System;

namespace SearchPictures.Model
{
    public interface ISearchPicturesModel
    {
        event EventHandler<ImageDataEventArgs> UpdateImageData;

        void SearchButtonClick(string searchString);
    }
}