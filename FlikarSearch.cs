using System;


namespace SearchPictures
{
    internal class FlikarSearch
    {
        public string PhotosId { get; set; }
        public string ImgTitle { get; set; }
        public string Scrt { get; set; }
        public string FarmeId { get; set; }
        public string ServerId { get; set; }

        public Uri ImgUrl => new Uri($"http://farm{FarmeId}.static.flickr.com/{ServerId}/{PhotosId}_{Scrt}.jpg");
    }
}