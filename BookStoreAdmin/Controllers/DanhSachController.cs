using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Controllers
{
    public class DanhSachController : Controller
    {
        // GET: DanhSach
        public ActionResult Index()
        {
            return View();
        }
    }
}