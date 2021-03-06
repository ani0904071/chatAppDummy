﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using ChatApplication.Dtos;
using ChatApplication.Models;

namespace ChatApplication.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<TblBook, BookListDto>();
            CreateMap<LoginDto, TblUser>();
            CreateMap<RegisterDto, TblUser>();
        }
    }
}
