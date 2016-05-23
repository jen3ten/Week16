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
    public class tblStudentsController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        public ActionResult Evans()
        {
            var evansStudents = from students in db.tblStudents
                                where students.LastName == "Evans"
                                select students;
            return View(evansStudents.ToList());
        }

        public ActionResult Highland()
        {

            var highlandStudents = from students in db.tblStudents
                                   where students.SchoolID == 1
                                   select students;
            return View(highlandStudents.ToList());
        }
        
        // GET: tblStudents
        /*public ActionResult Index()
        {
            var tblStudents = db.tblStudents.Include(t => t.tblSchool);
            return View(tblStudents.ToList());
        }*/

        public ActionResult Index(string id)
        {

            var tblStudents = db.tblStudents.Include(t => t.tblSchool);

            switch (id)
            {
                case "FirstName":
                    tblStudents = db.tblStudents.OrderBy(t => t.FirstName);
                    break;
                case "LastName":
                    tblStudents = db.tblStudents.OrderBy(t => t.LastName);
                    break;
                case "Grade":
                    tblStudents = db.tblStudents.OrderBy(t => t.Grade);
                    break;
                case "School":
                    tblStudents = db.tblStudents.OrderBy(t => t.tblSchool.Name);
                    break;
                default:
                    break;
            }


            return View(tblStudents.ToList());


        }

        // GET: tblStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // GET: tblStudents/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(db.tblSchools, "SchoolID", "Name");
            return View();
        }

        // POST: tblStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Grade,SchoolID")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.tblStudents.Add(tblStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolID = new SelectList(db.tblSchools, "SchoolID", "Name", tblStudent.SchoolID);
            return View(tblStudent);
        }

        // GET: tblStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolID = new SelectList(db.tblSchools, "SchoolID", "Name", tblStudent.SchoolID);
            return View(tblStudent);
        }

        // POST: tblStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Grade,SchoolID")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolID = new SelectList(db.tblSchools, "SchoolID", "Name", tblStudent.SchoolID);
            return View(tblStudent);
        }

        // GET: tblStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: tblStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudent tblStudent = db.tblStudents.Find(id);
            db.tblStudents.Remove(tblStudent);
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
