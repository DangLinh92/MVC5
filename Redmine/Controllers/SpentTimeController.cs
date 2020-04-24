using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redmine.Controllers
{
    public class SpentTimeController : Controller
    {
        // GET: SpentTime
        public ActionResult Index()
        {
            ViewBag.TitleItem = "SpentTime";
            return View();
        }
    }
}