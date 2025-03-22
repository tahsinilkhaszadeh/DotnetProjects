using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Web.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController
        public ActionResult Index()
        {
            return View();
        }

    }
}
