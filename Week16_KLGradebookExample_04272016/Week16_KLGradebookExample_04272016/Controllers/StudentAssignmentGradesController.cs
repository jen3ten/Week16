using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week16_KLGradebookExample_04272016.Models;

namespace Week16_KLGradebookExample_04272016.Controllers
{
    public class StudentAssignmentGradesController : Controller
    {
        private KLGradebookDBEntities db = new KLGradebookDBEntities();

        // GET: StudentAssignmentGrades
        public ActionResult Index()
        {
            var studentAssignmentGrades = db.StudentAssignmentGrades.Include(s => s.Assignment).Include(s => s.Student);
            return View(studentAssignmentGrades.ToList());
        }

        // GET: StudentAssignmentGrades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssignmentGrade studentAssignmentGrade = db.StudentAssignmentGrades.Find(id);
            if (studentAssignmentGrade == null)
            {
                return HttpNotFound();
            }
            return View(studentAssignmentGrade);
        }

        // GET: StudentAssignmentGrades/Create
        public ActionResult Create()
        {
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: StudentAssignmentGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,AssignmentID,PointsAwarded,Grade")] StudentAssignmentGrade studentAssignmentGrade)
        {
            if (ModelState.IsValid)
            {
                db.StudentAssignmentGrades.Add(studentAssignmentGrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "Title", studentAssignmentGrade.AssignmentID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentAssignmentGrade.StudentID);
            return View(studentAssignmentGrade);
        }

        // GET: StudentAssignmentGrades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssignmentGrade studentAssignmentGrade = db.StudentAssignmentGrades.Find(id);
            if (studentAssignmentGrade == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "Title", studentAssignmentGrade.AssignmentID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentAssignmentGrade.StudentID);
            return View(studentAssignmentGrade);
        }

        // POST: StudentAssignmentGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,AssignmentID,PointsAwarded,Grade")] StudentAssignmentGrade studentAssignmentGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAssignmentGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "Title", studentAssignmentGrade.AssignmentID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentAssignmentGrade.StudentID);
            return View(studentAssignmentGrade);
        }

        // GET: StudentAssignmentGrades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssignmentGrade studentAssignmentGrade = db.StudentAssignmentGrades.Find(id);
            if (studentAssignmentGrade == null)
            {
                return HttpNotFound();
            }
            return View(studentAssignmentGrade);
        }

        // POST: StudentAssignmentGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAssignmentGrade studentAssignmentGrade = db.StudentAssignmentGrades.Find(id);
            db.StudentAssignmentGrades.Remove(studentAssignmentGrade);
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
