using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week16_DriversDBPractice_04282016.Models;

namespace Week16_DriversDBPractice_04282016.Controllers
{
    public class CarUsersController : Controller
    {
        private DriversDBEntities db = new DriversDBEntities();

        // GET: CarUsers
        public ActionResult Index()
        {
            var carUsers = db.CarUsers.Include(c => c.Car).Include(c => c.Driver);
            return View(carUsers.ToList());
        }

        // GET: CarUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarUser carUser = db.CarUsers.Find(id);
            if (carUser == null)
            {
                return HttpNotFound();
            }
            return View(carUser);
        }

        // GET: CarUsers/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make");
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName");
            return View();
        }

        // POST: CarUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarUseID,DriverID,CarID,StartDate,EndDate")] CarUser carUser)
        {
            if (ModelState.IsValid)
            {
                db.CarUsers.Add(carUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make", carUser.CarID);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName", carUser.DriverID);
            return View(carUser);
        }

        // GET: CarUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarUser carUser = db.CarUsers.Find(id);
            if (carUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make", carUser.CarID);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName", carUser.DriverID);
            return View(carUser);
        }

        // POST: CarUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarUseID,DriverID,CarID,StartDate,EndDate")] CarUser carUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make", carUser.CarID);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "FirstName", carUser.DriverID);
            return View(carUser);
        }

        // GET: CarUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarUser carUser = db.CarUsers.Find(id);
            if (carUser == null)
            {
                return HttpNotFound();
            }
            return View(carUser);
        }

        // POST: CarUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarUser carUser = db.CarUsers.Find(id);
            db.CarUsers.Remove(carUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
