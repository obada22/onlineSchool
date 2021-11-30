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
    public class DevamZamanisController : Controller
    {
        private DBO_iss db = new DBO_iss();
        private GenerateId gId = new GenerateId();

        // GET: admin/DevamZamanis
        public ActionResult Index()
        {
            return View(db.DevamZamanis.ToList());
        }

        // GET: admin/DevamZamanis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevamZamani devamZamani = db.DevamZamanis.Find(id);
            if (devamZamani == null)
            {
                return HttpNotFound();
            }
            return View(devamZamani);
        }

        // GET: admin/DevamZamanis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/DevamZamanis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] DevamZamani devamZamani)
        {
            if (ModelState.IsValid)
            {
                db.DevamZamanis.Add(devamZamani);
                devamZamani.id= gId.geneID();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(devamZamani);
        }

        // GET: admin/DevamZamanis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevamZamani devamZamani = db.DevamZamanis.Find(id);
            if (devamZamani == null)
            {
                return HttpNotFound();
            }
            return View(devamZamani);
        }

        // POST: admin/DevamZamanis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] DevamZamani devamZamani)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devamZamani).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devamZamani);
        }

        // GET: admin/DevamZamanis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevamZamani devamZamani = db.DevamZamanis.Find(id);
            if (devamZamani == null)
            {
                return HttpNotFound();
            }
            return View(devamZamani);
        }

        // POST: admin/DevamZamanis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DevamZamani devamZamani = db.DevamZamanis.Find(id);
            db.DevamZamanis.Remove(devamZamani);
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
