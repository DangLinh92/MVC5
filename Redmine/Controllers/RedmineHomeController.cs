using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Redmine.Models;

namespace Redmine.Controllers
{
    public class RedmineHomeController : Controller
    {
        // GET: RedmineHome
        public ActionResult Index()
        {
            ViewBag.TitleItem = "Home";
            return View();
        }

        public string GetRoleOfUser(string userId)
        {
            string role = "";
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var roles = userManager.GetRoles(userId);
                role = roles.Count > 0 ?roles[0]:"";
            }
            return role;
        }
    }
}