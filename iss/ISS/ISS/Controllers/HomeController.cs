using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISS.Models;
using ISS.Models.Data;
using System.Data.Entity;
using System.Net;
using System.Globalization;

namespace ISS.Controllers
{
    public class HomeController : Controller
    {
        private DBO_iss db = new DBO_iss();

        // GET:Home page
        public ActionResult Index()
        {
            var news = db.news;
            return View(news.ToList());
        }

        public ActionResult About()
        {
          ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Student()
        {
            ViewBag.Message = "Student page.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }
        // GET: admin/news/Details/5
        public ActionResult newsDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        public ActionResult Announcement()
        {
            ViewBag.Message = "Announcement.";

            return View();
        }

        public ActionResult DilDegistir(string dil, string returnurl)
        {
            Session["dil"] = new CultureInfo(dil);
            return Redirect(returnurl);
        }
    }
}