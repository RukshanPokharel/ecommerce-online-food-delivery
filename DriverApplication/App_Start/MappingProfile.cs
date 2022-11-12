using AutoMapper;
using DriverApplication.DTOs;
using DriverApplication.DTOs.Driver;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper.CreateMap<Driver, DriverDto>();
            //Mapper.CreateMap<DriverDto, Driver>();
        }
    }
}