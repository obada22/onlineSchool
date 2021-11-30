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
using System.Globalization;
namespace ISS.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin , Student")]
    public class AnnouncementsController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gId = new GenerateId();

        // GET: admin/Announcements
        public ActionResult Index()
        {
            var announcements = db.Announcements.Include(a => a.AspNetUser).Include(a => a.Current_courses);
            return View(announcements.ToList());
        }

        // GET: admin/Announcements/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: admin/Announcements/Create
        public ActionResult Create()
        {
            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.current_cousre_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID");
            return View();
        }

        // POST: admin/Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "type,current_cousre_ID,teacher_ID,title,describe")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcement);
                announcement.announcement_ID = gId.geneID();
                announcement.create_date = DateTime.Now.Date;
                announcement.create_time = DateTime.Now.TimeOfDay;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email", announcement.teacher_ID);
            ViewBag.current_cousre_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID", announcement.current_cousre_ID);
            return View(announcement);
        }

        // GET: admin/Announcements/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email", announcement.teacher_ID);
            ViewBag.current_cousre_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID", announcement.current_cousre_ID);
            return View(announcement);
        }

        // POST: admin/Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "announcement_ID,type,current_cousre_ID,teacher_ID,create_date,create_time,title,describe")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_ID = new SelectList(db.AspNetUsers, "Id", "Email", announcement.teacher_ID);
            ViewBag.current_cousre_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID", announcement.current_cousre_ID);
            return View(announcement);
        }

        // GET: admin/Announcements/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: admin/Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
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
