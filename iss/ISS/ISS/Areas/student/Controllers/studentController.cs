using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISS.Areas.student.Controllers
{
    [Authorize(Roles = "Admin,Student")]
    public class studentController : Controller
    {
        // GET: student/student
        public ActionResult Index()
        {
            return View();
        }
    }
}
