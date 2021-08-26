using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Commons;
using DataAccess.Entity;
using WebApi.Models;



namespace WebApi.AutoMapper


{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<IVehicleMake, MakeEntity>().ReverseMap();
            CreateMap<IVehicleModel, ModelEntity>().ReverseMap();
            CreateMap<MakeRest, IVehicleMake>().ReverseMap();
            CreateMap<ModelRest, IVehicleModel>().ReverseMap();
        }
    }
}