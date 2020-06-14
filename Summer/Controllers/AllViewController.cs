using System.Web.Mvc;

namespace Summer.Controllers
{
    [Authorize]
    public class AllViewController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}