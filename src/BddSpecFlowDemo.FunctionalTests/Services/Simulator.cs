using System.Net;

namespace BddSpecFlowDemo.FunctionalTests.Services
{
    public class Simulator
    {
        private readonly string _baseUrl;

        public Simulator(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public void ToggleAlbumSimulation(bool turnOnSimulation)
        {
            var url = string.Format("{0}Simulators/Switch?simulatorKey=Albums&value={1}", _baseUrl, turnOnSimulation);
            new WebClient().DownloadString(url);
        }
    }
}