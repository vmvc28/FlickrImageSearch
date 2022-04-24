using System;
using System.Collections.Generic;

using SearchPictures.Model;


namespace SearchPictures
{
    public class ImageDataEventArgs : EventArgs
    {
        public IList<ImageData> Images { get; }

        public ImageDataEventArgs(IList<ImageData> images)
        {
            Images = images;
        }
    }
}