using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // LOGIN (GET)
        public ActionResult Login()
        {
            return View();
        }

        // LOGIN (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users
                .FirstOrDefault(u => u.Email == email && u.PasswordHash == password);

            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.Name;

                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Error = "Invalid Email or Password";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
