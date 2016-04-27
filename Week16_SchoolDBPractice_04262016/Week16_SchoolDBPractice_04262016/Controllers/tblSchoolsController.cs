using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week16_SchoolDBPractice_04262016.Models;

namespace Week16_SchoolDBPractice_04262016.Controllers
{
    public class tblSchoolsController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: tblSchools
        public ActionResult Index()
        {
            return View(db.tblSchools.ToList());
        }

        // GET: tblSchools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchool tblSchool = db.tblSchools.Find(id);
            if (tblSchool == null)
            {
                return HttpNotFound();
            }
            return View(tblSchool);
        }

        // GET: tblSchools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSchools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchoolID,Name,District")] tblSchool tblSchool)
        {
            if (ModelState.IsValid)
            {
                db.tblSchools.Add(tblSchool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSchool);
        }

        // GET: tblSchools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchool tblSchool = db.tblSchools.Find(id);
            if (tblSchool == null)
            {
                return HttpNotFound();
            }
            return View(tblSchool);
        }

        // POST: tblSchools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchoolID,Name,District")] tblSchool tblSchool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSchool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSchool);
        }

        // GET: tblSchools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchool tblSchool = db.tblSchools.Find(id);
            if (tblSchool == null)
            {
                return HttpNotFound();
            }
            return View(tblSchool);
        }

        // POST: tblSchools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSchool tblSchool = db.tblSchools.Find(id);
            db.tblSchools.Remove(tblSchool);
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
