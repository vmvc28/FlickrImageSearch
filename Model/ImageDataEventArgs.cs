using System;
using System.Collections.Generic;


namespace SearchPictures.Model
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