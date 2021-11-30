using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISS.Models.Data;
using ISS.Areas.admin.Models;

namespace ISS.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin,Student")]
    public class Current_coursesController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gId = new GenerateId();
        // GET: admin/Current_courses
        public ActionResult Index()
        {
            var current_courses = db.Current_courses.Include(c => c.AspNetUser).Include(c => c.Course);
            return View(current_courses.ToList());
        }

        // GET: admin/Current_courses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Current_courses current_courses = db.Current_courses.Find(id);
            if (current_courses == null)
            {
                return HttpNotFound();
            }
            return View(current_courses);
        }

        // GET: admin/Current_courses/Create
        public ActionResult Create()
        {
            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.course_ID = new SelectList(db.Courses, "course_ID", "course_ID");
            return View();
        }

        // POST: admin/Current_courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "course_ID,teacher_ID,describe")] Current_courses current_courses)
        {
           

            if (ModelState.IsValid)
            {
                current_courses.current_cousre_ID = gId.geneID();
                db.Current_courses.Add(current_courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email", current_courses.teacher_ID);
            ViewBag.course_ID = new SelectList(db.Courses, "course_ID", "course_ID", current_courses.course_ID);
            return View(current_courses);
        }

        // GET: admin/Current_courses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Current_courses current_courses = db.Current_courses.Find(id);
            if (current_courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email", current_courses.teacher_ID);
            ViewBag.course_ID = new SelectList(db.Courses, "course_ID", "course_ID", current_courses.course_ID);
            return View(current_courses);
        }

        // POST: admin/Current_courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "current_cousre_ID,course_ID,teacher_ID,describe")] Current_courses current_courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(current_courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email", current_courses.teacher_ID);
            ViewBag.course_ID = new SelectList(db.Courses, "course_ID", "course_ID", current_courses.course_ID);
            return View(current_courses);
        }

        // GET: admin/Current_courses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Current_courses current_courses = db.Current_courses.Find(id);
            if (current_courses == null)
            {
                return HttpNotFound();
            }
            return View(current_courses);
        }

        // POST: admin/Current_courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Current_courses current_courses = db.Current_courses.Find(id);
            db.Current_courses.Remove(current_courses);
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
