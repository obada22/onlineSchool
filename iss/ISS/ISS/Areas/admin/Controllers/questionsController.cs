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
    public class questionsController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gId = new GenerateId();

        // GET: admin/questions
        public ActionResult Index()
        {
            var questions = db.questions.Include(q => q.quiz);
            return View(questions.ToList());
        }

        // GET: admin/questions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: admin/questions/Create
        public ActionResult Create()
        {
            ViewBag.quizID = new SelectList(db.quizs, "quizID", "Course_ID");
            return View();
        }

        // POST: admin/questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questionID,quizID,question_number,timestamps,describe,imagePath")] question question)
        {
            if (ModelState.IsValid)
            {
                db.questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.quizID = new SelectList(db.quizs, "quizID", "Course_ID", question.quizID);
            return View(question);
        }

        // GET: admin/questions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.quizID = new SelectList(db.quizs, "quizID", "Course_ID", question.quizID);
            return View(question);
        }

        // POST: admin/questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questionID,quizID,question_number,timestamps,describe,imagePath")] question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.quizID = new SelectList(db.quizs, "quizID", "Course_ID", question.quizID);
            return View(question);
        }

        // GET: admin/questions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            question question = db.questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: admin/questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            question question = db.questions.Find(id);
            db.questions.Remove(question);
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
