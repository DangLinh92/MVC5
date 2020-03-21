using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVanBan.Models;

namespace QuanLyVanBan.Controllers
{
    public class VanBanController : Controller
    {
        public QLVanBanModel Model => model ?? (model = new QLVanBanModel());
        private QLVanBanModel model;

        // GET: VanBan
        public ActionResult Index()
        {
            IEnumerable<stanfVanBan> lstVanBan = Model.stanfVanBans;
            return View(lstVanBan);
        }

        public ActionResult Create()
        {
            PrepareDataForDropList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(stanfVanBan vanBan, HttpPostedFileBase fUpload)
        {
            if (ModelState.IsValid)
            {
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(fUpload.FileName);
                    fUpload.SaveAs(Server.MapPath("~/Content/Files/"+fileName));
                    vanBan.TenFile = fileName;
                    vanBan.DuongDan = "~/Content/Files/" + fileName;
                    if (fileName != null)
                    {
                        var arr = fileName.Split('.');
                        vanBan.DinhDang = arr[arr.Length - 1];
                    }

                    Model.stanfVanBans.Add(vanBan);
                    Model.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            PrepareDataForDropList();
            return View();
        }

        public ActionResult Update(string id)
        {
            PrepareDataForDropList();
            var vanban = Model.stanfVanBans.SingleOrDefault(v => v.Id == id);
            return View(vanban);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(stanfVanBan vanBan, HttpPostedFileBase TenFile)
        {
            PrepareDataForDropList();
            if (ModelState.IsValid)
            {
                if (TenFile != null && TenFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(TenFile.FileName);
                    TenFile.SaveAs(Server.MapPath("~/Content/Files/" + fileName));
                    vanBan.TenFile = fileName;
                    vanBan.DuongDan = "~/Content/Files/" + fileName;
                    if (fileName != null)
                    {
                        var arr = fileName.Split('.');
                        vanBan.DinhDang = arr[arr.Length - 1];
                    }

                    stanfVanBan vanBanOld = Model.stanfVanBans.First(v => v.Id == vanBan.Id);
                    if (vanBanOld != null)
                    {
                        Model.Entry(vanBanOld).CurrentValues.SetValues(vanBan);
                    }
                    Model.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            stanfVanBan vanBan = Model.stanfVanBans.First(s => s.Id == id);
            if (vanBan != null)
            {
                Model.stanfVanBans.Remove(vanBan);
                Model.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        private void PrepareDataForDropList()
        {
            ViewBag.LoaiVanBan = Model.stanfLoaiVanBans.ToList();
            ViewBag.DonVi = Model.stanfDonVis.ToList();
        }
    }
}