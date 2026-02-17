using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        // ================= DASHBOARD (PROTECTED) =================
        public ActionResult Dashboard()
        {
            // 👉 If not logged in, redirect to login page
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Users");

            // 👉 Dashboard stats
            ViewBag.UserName = Session["UserName"];
            ViewBag.TotalUsers = db.Users.Count();
            ViewBag.TotalMedicines = db.Medicines.Count();
            ViewBag.LowStock = db.Medicines.Count(m => m.Stock < 10);

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
