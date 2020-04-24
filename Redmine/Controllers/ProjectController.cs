using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redmine.Models;
using Redmine.Persistence;

namespace Redmine.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            ViewBag.TitleItem = "Project";
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.TitleItem = "Create Project";
            return View();
        }

        public ActionResult ListProject()
        {
            using (var context = new UnitOfWork(ApplicationDbContext.Create()))
            {
                var projects = context.Projects.GetAll();
                return PartialView("_ProjectPartialPage",projects);
            }
        }
    }
}