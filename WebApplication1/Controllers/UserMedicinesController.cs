using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserMedicinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // ==============================
        // INDEX - Show only logged user medicines
        // ==============================
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            int userId = (int)Session["UserId"];

            var medicines = db.UserMedicines
                              .Where(m => m.UserId == userId)
                              .ToList();

            return View(medicines);
        }

        // ==============================
        // DETAILS
        // ==============================
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            UserMedicine userMedicine = db.UserMedicines.Find(id);

            if (userMedicine == null)
                return HttpNotFound();

            return View(userMedicine);
        }

        // ==============================
        // CREATE - GET
        // ==============================
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        // ==============================
        // CREATE - POST
        // ==============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserMedicine userMedicine)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                userMedicine.UserId = (int)Session["UserId"];
                userMedicine.RemainingQuantity = userMedicine.TotalQuantity;
                userMedicine.Status = "Pending";

                db.UserMedicines.Add(userMedicine);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(userMedicine);
        }

        // ==============================
        // EDIT - GET
        // ==============================
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            UserMedicine userMedicine = db.UserMedicines.Find(id);

            if (userMedicine == null)
                return HttpNotFound();

            return View(userMedicine);
        }

        // ==============================
        // EDIT - POST
        // ==============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserMedicine userMedicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMedicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userMedicine);
        }

        // ==============================
        // DELETE - GET
        // ==============================
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            UserMedicine userMedicine = db.UserMedicines.Find(id);

            if (userMedicine == null)
                return HttpNotFound();

            return View(userMedicine);
        }

        // ==============================
        // DELETE - POST
        // ==============================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMedicine userMedicine = db.UserMedicines.Find(id);
            db.UserMedicines.Remove(userMedicine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ==============================
        // MARK AS TAKEN
        // ==============================
        public ActionResult MarkTaken(int id)
        {
            var medicine = db.UserMedicines.Find(id);

            if (medicine != null)
            {
                medicine.Status = "Taken";

                if (medicine.RemainingQuantity > 0)
                    medicine.RemainingQuantity--;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ==============================
        // MARK AS MISSED
        // ==============================
        public ActionResult MarkMissed(int id)
        {
            var medicine = db.UserMedicines.Find(id);

            if (medicine != null)
            {
                medicine.Status = "Missed";
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}