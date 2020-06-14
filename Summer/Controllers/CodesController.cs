using Summer.Models;
using System.Linq;
using System.Web.Mvc;

namespace Summer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CodesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Codes
        public ActionResult Index()
        {
            return View(db.Codes.ToList());
        }








        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
