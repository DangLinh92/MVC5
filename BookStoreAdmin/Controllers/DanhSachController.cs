using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreAdmin.Models;

namespace BookStoreAdmin.Controllers
{
    public class DanhSachController : Controller
    {
        // GET: DanhSach
        public ActionResult Index(string tukhoa,string chudeid)
        {
            HienThiDanhSachChuDe();

            var lstSachByTuKhoa = DataProvider.Entities.Saches.Where(x =>
                x.TenSach.Contains(tukhoa) || x.TacGia.Contains(tukhoa) || x.MoTa.Contains(tukhoa));
            var lstSachByChuDe = DataProvider.Entities.Saches.Where(x => x.ChuDeId.Contains(chudeid));

            IQueryable<Sache> lstSach = null;
            if (!string.IsNullOrEmpty(tukhoa) && string.IsNullOrEmpty(chudeid))
            {
                lstSach = lstSachByTuKhoa;
            }
            else if (!string.IsNullOrEmpty(chudeid) && string.IsNullOrEmpty(tukhoa))
            {
                lstSach = lstSachByChuDe;
            }
            else
            {
                lstSach = DataProvider.Entities.Saches;
            }

            return View(lstSach);
        }

        public ActionResult Create()
        {
            HienThiDanhSachChuDe();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sache objSache,HttpPostedFileBase fileUpload)
        {
            if (string.IsNullOrEmpty(objSache.TenSach))
            {
                ModelState.AddModelError("TenSach","Bạn cần nhập tên sách");
            }

            if (ModelState.IsValid)
            {
                objSache.NgayTao = DateTime.Now;
                objSache.NgayXuatBan = DateTime.Now;

                string fileName = "";
                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Server.MapPath("~/Content/images/"+fileName));
                    objSache.AnhDaiDien = fileName;
                }

                DataProvider.Entities.Saches.Add(objSache);
                DataProvider.Entities.SaveChanges();
                return RedirectToAction("Index");
            }

            HienThiDanhSachChuDe();
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        private void HienThiDanhSachChuDe(string chudeId = "")
        {
            var lstChuDe = DataProvider.Entities.ChuDes;
            ViewBag.ChuDe = new SelectList(lstChuDe, "MaChuDe", "TenChuDe");
        }
    }
}