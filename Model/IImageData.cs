using System;

namespace SearchPictures.Model
{
    public interface IImageData
    {
        string FarmeId { get; set; }
        string ImgTitle { get; set; }
        Uri ImgUrl { get; }
        string PhotosId { get; set; }
        string Scrt { get; set; }
        string ServerId { get; set; }
    }
}