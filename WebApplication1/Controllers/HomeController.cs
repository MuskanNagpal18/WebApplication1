using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
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

        public ActionResult Dashboard()
        {
            ViewBag.TotalUsers = db.Users.Count();
            ViewBag.TotalMedicines = db.Medicines.Count();
            ViewBag.LowStock = db.Medicines.Count(m => m.Stock < 10);

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Features()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult AdminInfo()
        {
            return View();
        }

    }
}