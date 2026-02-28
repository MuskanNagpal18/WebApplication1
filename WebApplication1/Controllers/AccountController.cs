using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "User"; // default role
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var existingUser = db.Users
                .FirstOrDefault(u => u.Email == user.Email
                                  && u.PasswordHash == user.PasswordHash);

            if (existingUser != null)
            {
                Session["UserId"] = existingUser.UserId;
                Session["UserName"] = existingUser.Name;
                Session["Role"] = existingUser.Role;

                if (existingUser.Role == "Admin")
                    return RedirectToAction("AdminDashboard", "Admin");

                return RedirectToAction("Index", "UserMedicines");
            }

            ViewBag.Error = "Invalid Email or Password";
            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
    
}