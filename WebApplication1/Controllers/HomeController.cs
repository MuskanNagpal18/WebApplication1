using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
        public ActionResult 
        Index()
        {
      
=======
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
>>>>>>> b5c5613ed6eb08e680c44fc77e7539aedddb3a38
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        // NEW DASHBOARD ACTION
        // NEW DASHBOARD ACTION
        public ActionResult Dashboard()
        {
            ViewBag.TotalUsers = db.Users.Count();
            ViewBag.TotalMedicines = db.Medicines.Count();
            ViewBag.LowStock = db.Medicines.Count(m => m.Stock < 10);

            return View();
        }
    }
    }