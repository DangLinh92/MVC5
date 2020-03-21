using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreAdmin.Models;

namespace BookStoreAdmin.Controllers.Api
{
    public class DanhSachController : ApiController
    {
        private BookStoreModel context;

        public DanhSachController()
        {
            context = DataProvider.Entities;
        }

        // GET api/DanhSach
        public IEnumerable<Sache> GetDanhSach()
        {
            return context.Saches.ToList();
        }

        // Get api/sach/1
        public Sache GeDanhSach(int id)
        {
            var sach = context.Saches.SingleOrDefault(c => c.Id == id);
            if (sach == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return sach;
        }

        // POST /api/sache
        [System.Web.Http.HttpPost]
        public Sache CreateDanhSach(Sache sache)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            context.Saches.Add(sache);
            context.SaveChanges();
            return sache;
        }

        // PUT /api/sache/1
        [HttpPut]
        public void UpdateDanhSach(int id, Sache sache)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var sacheInDB = context.Saches.SingleOrDefault(c => c.Id == id);
            if(sacheInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            sacheInDB.TacGia = sache.TacGia;
            context.SaveChanges();
        }

        // DELETE /api/sache/1
        [System.Web.Http.HttpDelete]
        public void DeleteDanhSach(int id)
        {
            var sachInDB = context.Saches.SingleOrDefault(c => c.Id == id);
            if(sachInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Saches.Remove(sachInDB);
            context.SaveChanges();
        }
    }
}
