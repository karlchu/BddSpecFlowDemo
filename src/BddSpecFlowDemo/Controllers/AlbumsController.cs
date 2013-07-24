using System.Web;
using System.Web.Mvc;
using BddSpecFlowDemo.Services;

namespace BddSpecFlowDemo.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        //
        // GET: /Albums/

        public ActionResult Index()
        {
            return Content("");
        }

        public ActionResult Search(string title)
        {
            var album = _albumsService.SearchByTitle(title);
            if (album != null)
            {
                return Content(string.Format("{0}|{1}", album.Title, album.Artist));
            }
            else
            {
                throw new HttpException(404, "Album not found");
            }
        }
    }
}
