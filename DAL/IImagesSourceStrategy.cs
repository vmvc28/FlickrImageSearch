using System;
using System.Threading.Tasks;

using SearchPictures.Model;


namespace SearchPictures.DAL
{
    public interface IImagesSourceStrategy
    {
        event EventHandler<ImageDataEventArgs> UpdateImageData;

        Task GetDataFromSource(string searchString);
    }
}