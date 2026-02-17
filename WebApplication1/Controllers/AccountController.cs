using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                TempData["Error"] = "Please enter username and password";
                return RedirectToAction("Index", "Home");
            }

            if (db.Users.Any(u => u.Username == username))
            {
                TempData["Error"] = "Username already exists";
                return RedirectToAction("Index", "Home");
            }

            var user = new User
            {
                Username = username,
                Password = password
            };

            db.Users.Add(user);
            db.SaveChanges();

            TempData["Success"] = "Registration successful";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users
                         .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                TempData["Error"] = "Invalid username or password";
                return RedirectToAction("Index", "Home");
            }

            Session["User"] = user.Username;
            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
