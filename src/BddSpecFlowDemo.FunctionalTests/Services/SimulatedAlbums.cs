using System.IO;
using System.Net;

namespace BddSpecFlowDemo.FunctionalTests.Services
{
    public class SimulatedAlbums
    {
        private readonly string _baseUrl;

        public SimulatedAlbums(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public void Add(string title, string artist)
        {
            var url = string.Format("{0}SimulatedAlbums", _baseUrl);
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            var requestStream = request.GetRequestStream();
            using (var writer = new StreamWriter(requestStream))
            {
                writer.Write(string.Format("{0}|{1}", title, artist));
            }
            request.GetResponse();
        }

        public void Clear()
        {
            var url = string.Format("{0}SimulatedAlbums/Clear", _baseUrl);
            new WebClient().DownloadString(url);
        }
    }
}