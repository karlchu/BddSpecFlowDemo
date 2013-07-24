using System.IO;
using System.Web.Mvc;
using BddSpecFlowDemo.Simulation.Services;

namespace BddSpecFlowDemo.Controllers
{
    public class SimulatedAlbumsController : Controller
    {
        private readonly ISimulatedAlbumStorage _simulatedAlbumStorage;

        public SimulatedAlbumsController(ISimulatedAlbumStorage simulatedAlbumStorage)
        {
            _simulatedAlbumStorage = simulatedAlbumStorage;
        }

        public ActionResult Index()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Index(string content)
        {
            using (var reader = new StreamReader(Request.InputStream))
            {
                var parts = reader.ReadToEnd().Split('|');
                _simulatedAlbumStorage.Add(parts[0], parts[1]);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            _simulatedAlbumStorage.Clear();
            return RedirectToAction("Index");
        }
    }
}
