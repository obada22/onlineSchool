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
    [Authorize(Roles = "Admin")]
    public class quizsController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gId = new GenerateId();

        // GET: admin/quizs
        public ActionResult Index()
        {
            var quizs = db.quizs.Include(q => q.AspNetUser).Include(q => q.Course).Include(q => q.type);
            return View(quizs.ToList());
        }

        // GET: admin/quizs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = db.quizs.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: admin/quizs/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Course_ID = new SelectList(db.Courses, "course_ID", "course_ID");
            ViewBag.typeID = new SelectList(db.types, "typeID", "name");
            return View();
        }

        // POST: admin/quizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "quizID,time,created_date,Course_ID,description,timelimit,name,user_id,typeID")] quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.quizs.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email", quiz.user_id);
            ViewBag.Course_ID = new SelectList(db.Courses, "course_ID", "course_ID", quiz.Course_ID);
            ViewBag.typeID = new SelectList(db.types, "typeID", "name", quiz.typeID);
            return View(quiz);
        }

        // GET: admin/quizs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = db.quizs.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email", quiz.user_id);
            ViewBag.Course_ID = new SelectList(db.Courses, "course_ID", "course_ID", quiz.Course_ID);
            ViewBag.typeID = new SelectList(db.types, "typeID", "name", quiz.typeID);
            return View(quiz);
        }

        // POST: admin/quizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "quizID,time,created_date,Course_ID,description,timelimit,name,user_id,typeID")] quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email", quiz.user_id);
            ViewBag.Course_ID = new SelectList(db.Courses, "course_ID", "course_ID", quiz.Course_ID);
            ViewBag.typeID = new SelectList(db.types, "typeID", "name", quiz.typeID);
            return View(quiz);
        }

        // GET: admin/quizs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = db.quizs.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: admin/quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            quiz quiz = db.quizs.Find(id);
            db.quizs.Remove(quiz);
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
