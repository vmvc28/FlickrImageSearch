using System.Windows.Media.Imaging;


namespace SearchPictures
{
    class SearchViewModel
    {
        private BitmapImage imageData;

        public BitmapImage ImageData
        {
            get { return this.imageData; }
            set { this.imageData = value; }
        }
    }
}