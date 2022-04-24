using System;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;


namespace SearchPictures.Model
{
    public class SearchPicturesModel : ISearchPicturesModel
    {
        private HttpClient myHttpClient;

        private const string FlickerKey = "7de156ee2c901128fbd943b92f0b35d2";

        private string SearchUrl = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&text={1}";

        public event EventHandler<ImageDataEventArgs> UpdateImageData;

        public async void SearchButtonClick(string searchString)

        {
            myHttpClient = new HttpClient();

            HttpResponseMessage getResponse = await myHttpClient.GetAsync(String.Format(SearchUrl, FlickerKey, searchString));

            ParseImage(getResponse);
        }

        private async void ParseImage(HttpResponseMessage httpResponseMessage)

        {
            XDocument doc = XDocument.Parse(await httpResponseMessage.Content.ReadAsStringAsync());

            var imageData = doc.Descendants("photo")
                .Select(results => new FlikarSearch
                {
                    PhotosId = results.Attribute("id")?.Value.ToString(),
                    ImgTitle = results.Attribute("title")?.Value.ToString(),
                    Scrt = results.Attribute("secret")?.Value.ToString(),
                    FarmeId = results.Attribute("farm")?.Value.ToString(),
                    ServerId = results.Attribute("server")?.Value.ToString()
                }).ToList();

            UpdateImageData?.Invoke(this, new ImageDataEventArgs(imageData));
        }
    }
}