using System.Net;

namespace BddSpecFlowDemo.FunctionalTests.Services
{
    public class MusicCatalogueService
    {
        private readonly string _baseUrl;

        public MusicCatalogueService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string SearchAlbumByTitle(string word)
        {
            var webClient = new WebClient();
            try
            {
                return webClient.DownloadString(string.Format("{0}albums/search?title={1}", _baseUrl, word));
            }
            catch (WebException)
            {
                return string.Empty;
            }
        }
    }
}