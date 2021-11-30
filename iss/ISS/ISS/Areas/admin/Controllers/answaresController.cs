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
    [Authorize(Roles = "Admin")]
    public class answaresController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gId = new GenerateId();

        // GET: admin/answares
        public async Task<ActionResult> Index()
        {
            var answares = db.answares.Include(a => a.question);
            return View(await answares.ToListAsync());
        }

        // GET: admin/answares/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            answare answare = await db.answares.FindAsync(id);
            if (answare == null)
            {
                return HttpNotFound();
            }
            return View(answare);
        }

        // GET: admin/answares/Create
        public ActionResult Create()
        {
            ViewBag.questionID = new SelectList(db.questions, "questionID", "quizID");
            return View();
        }

        // POST: admin/answares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "answareID,iscorrect,text,answare_number,questionID")] answare answare)
        {
            if (ModelState.IsValid)
            {
                db.answares.Add(answare);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.questionID = new SelectList(db.questions, "questionID", "quizID", answare.questionID);
            return View(answare);
        }

        // GET: admin/answares/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            answare answare = await db.answares.FindAsync(id);
            if (answare == null)
            {
                return HttpNotFound();
            }
            ViewBag.questionID = new SelectList(db.questions, "questionID", "quizID", answare.questionID);
            return View(answare);
        }

        // POST: admin/answares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "answareID,iscorrect,text,answare_number,questionID")] answare answare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answare).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.questionID = new SelectList(db.questions, "questionID", "quizID", answare.questionID);
            return View(answare);
        }

        // GET: admin/answares/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            answare answare = await db.answares.FindAsync(id);
            if (answare == null)
            {
                return HttpNotFound();
            }
            return View(answare);
        }

        // POST: admin/answares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            answare answare = await db.answares.FindAsync(id);
            db.answares.Remove(answare);
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
