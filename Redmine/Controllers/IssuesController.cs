using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redmine.Controllers
{
    public class IssuesController : Controller
    {
        // GET: Issues
        public ActionResult Index()
        {
            ViewBag.TitleItem = "Issues";
            return View();
        }
    }
}