using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookStoreAdmin.Dtos;
using BookStoreAdmin.Models;

namespace BookStoreAdmin.App_Start
{
    public class MappingConfig
    {
        public static IMapper Mapping;
        public static void RegisterMapping()
        {
            var configuration = new MapperConfiguration(cfg=>
            {
                {
                    cfg.CreateMap<Sache, SacheDto>();
                    cfg.CreateMap<SacheDto, Sache>();
                }
            });
            Mapping = configuration.CreateMapper();
        }
    }
}