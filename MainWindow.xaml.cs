using System;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Xml.Linq;


namespace SearchPictures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient myHttpClient;

        private const string FlickerKey = "7de156ee2c901128fbd943b92f0b35d2";

        private string SearchUrl = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&text={1}";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)

        {
            myHttpClient = new HttpClient();

            HttpResponseMessage getResponse = await myHttpClient.GetAsync(String.Format(SearchUrl, FlickerKey, ImgText.Text));

            ImagePas(getResponse);
        }

        private async void ImagePas(HttpResponseMessage Htpmsg)

        {
            XDocument doc = XDocument.Parse(await Htpmsg.Content.ReadAsStringAsync());

            var photo = doc.Descendants("photo")
                .Select(results => new FlikarSearch
                {
                    PhotosId = results.Attribute("id")?.Value.ToString(),
                    ImgTitle = results.Attribute("title")?.Value.ToString(),
                    Scrt = results.Attribute("secret")?.Value.ToString(),
                    FarmeId = results.Attribute("farm")?.Value.ToString(),
                    ServerId = results.Attribute("server")?.Value.ToString()
                }).ToList();

            ImageList.ItemsSource = photo;
        }
    }
}