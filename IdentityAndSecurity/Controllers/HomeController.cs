using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityAndSecurity.Controllers
{
    [AllowAnonymous] // using controller.
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // using in action
            if (User.IsInRole("Develop"))
            {
                return View();
            }
            else
            {
              return  RedirectToAction("Contact");
            }
            
        }

        [Authorize(Roles = "Develop")]
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
    }
}