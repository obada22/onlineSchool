using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISS.Models.Data;
using ISS.Areas.admin.Models;

namespace ISS.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    public class Courses_ProgramController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gened = new GenerateId();

        // GET: admin/Courses_Program
        public async Task<ActionResult> Index()
        {
            var courses_Program = db.Courses_Program.Include(c => c.Current_courses).Include(c => c.Day).Include(c => c.DevamZamani);
            return View(await courses_Program.ToListAsync());
        }

        // GET: admin/Courses_Program/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses_Program courses_Program = await db.Courses_Program.FindAsync(id);
            if (courses_Program == null)
            {
                return HttpNotFound();
            }
            return View(courses_Program);
        }

        // GET: admin/Courses_Program/Create
        public ActionResult Create()
        {
            ViewBag.Courrnt_course_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID");
            ViewBag.day_ID = new SelectList(db.Days, "day_ID", "day1");
            ViewBag.devam_ID = new SelectList(db.DevamZamanis, "id", "Name");
            return View();
        }

        // POST: admin/Courses_Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Courrnt_course_ID,devam_ID,start_time,finish_time")] Courses_Program courses_Program )
        {
          
            if (ModelState.IsValid)
            {
                courses_Program.program_ID = gened.geneID();
                db.Courses_Program.Add(courses_Program);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Courrnt_course_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID", courses_Program.Courrnt_course_ID);
            ViewBag.day_ID = new SelectList(db.Days, "day_ID", "day1", courses_Program.day_ID);
            ViewBag.devam_ID = new SelectList(db.DevamZamanis, "id", "Name", courses_Program.devam_ID);
            return View(courses_Program);
        }

        // GET: admin/Courses_Program/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses_Program courses_Program = await db.Courses_Program.FindAsync(id);
            if (courses_Program == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courrnt_course_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID", courses_Program.Courrnt_course_ID);
            ViewBag.day_ID = new SelectList(db.Days, "day_ID", "day1", courses_Program.day_ID);
            ViewBag.devam_ID = new SelectList(db.DevamZamanis, "id", "Name", courses_Program.devam_ID);
            return View(courses_Program);
        }

        // POST: admin/Courses_Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "program_ID,day_ID,Courrnt_course_ID,devam_ID,start_time,finish_time")] Courses_Program courses_Program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses_Program).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Courrnt_course_ID = new SelectList(db.Current_courses, "current_cousre_ID", "course_ID", courses_Program.Courrnt_course_ID);
            ViewBag.day_ID = new SelectList(db.Days, "day_ID", "day1", courses_Program.day_ID);
            ViewBag.devam_ID = new SelectList(db.DevamZamanis, "id", "Name", courses_Program.devam_ID);
            return View(courses_Program);
        }

        // GET: admin/Courses_Program/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses_Program courses_Program = await db.Courses_Program.FindAsync(id);
            if (courses_Program == null)
            {
                return HttpNotFound();
            }
            return View(courses_Program);
        }

        // POST: admin/Courses_Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Courses_Program courses_Program = await db.Courses_Program.FindAsync(id);
            db.Courses_Program.Remove(courses_Program);
            await db.SaveChangesAsync();
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
