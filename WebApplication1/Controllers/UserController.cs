using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UserDashboard()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            int userId = (int)Session["UserId"];

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var medicines = db.UserMedicines
                                  .Where(m => m.UserId == userId)
                                  .ToList();

                return View(medicines);
            }
        }
    }
}