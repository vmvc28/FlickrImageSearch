using System;
using System.Collections.Generic;

using SearchPictures.Model;


namespace SearchPictures
{
    public class ImageDataEventArgs : EventArgs
    {
        public IList<FlikarSearch> Images { get; }

        public ImageDataEventArgs(IList<FlikarSearch> images)
        {
            Images = images;
        }
    }
}