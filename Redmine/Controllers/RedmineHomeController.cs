using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redmine.Controllers
{
    public class RedmineHomeController : Controller
    {
        // GET: RedmineHome
        public ActionResult Index()
        {
            return View();
        }
    }
}