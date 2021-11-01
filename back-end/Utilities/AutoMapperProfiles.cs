﻿using AutoMapper;
using back_end.DTOs;
using back_end.Entities;

namespace back_end.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
        }
    }
}
