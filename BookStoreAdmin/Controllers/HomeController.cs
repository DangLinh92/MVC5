using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreAdmin.Models;

namespace BookStoreAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var lstSach = DataProvider.EntityModel.Saches;
            return View(lstSach);
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

        public ActionResult Detail(string id)
        {
            var sach = DataProvider.EntityModel.Saches.FirstOrDefault(x => ""+x.Id == id);
            return View(sach);
        }
    }
}