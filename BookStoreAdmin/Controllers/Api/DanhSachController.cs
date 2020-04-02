using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BookStoreAdmin.App_Start;
using BookStoreAdmin.Dtos;
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
        public IEnumerable<SacheDto> GetDanhSach()
        {
            return context.Saches.ToList().Select(MappingConfig.Mapping.Map<Sache,SacheDto>);
        }

        // Get api/sach/1
        public SacheDto GeDanhSach(int id)
        {
            var sach = context.Saches.SingleOrDefault(c => c.Id == id);
            if (sach == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return MappingConfig.Mapping.Map<Sache,SacheDto>(sach);
        }

        // POST /api/sache
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateDanhSach(SacheDto sache)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var sach = MappingConfig.Mapping.Map<SacheDto, Sache>(sache);
            context.Saches.Add(sach);
            context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + sache.Id),
                sach); // MappingConfig.Mapping.Map<Sache, SacheDto>(sache);
        }

        // PUT /api/sache/1
        [HttpPut]
        public void UpdateDanhSach(int id, SacheDto sache)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var sacheInDB = context.Saches.SingleOrDefault(c => c.Id == id);
            if(sacheInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            MappingConfig.Mapping.Map<SacheDto, Sache>(sache, sacheInDB);
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
