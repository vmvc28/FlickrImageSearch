using System;


namespace SearchPictures.Model
{
    public class ImageData
    {
        public string PhotosId { get; set; }
        public string ImgTitle { get; set; }
        public string Secret { get; set; }
        public string FrameId { get; set; }
        public string ServerId { get; set; }

        public Uri ImgUrl => new Uri($"http://farm{FrameId}.static.flickr.com/{ServerId}/{PhotosId}_{Secret}.jpg");
    }
}