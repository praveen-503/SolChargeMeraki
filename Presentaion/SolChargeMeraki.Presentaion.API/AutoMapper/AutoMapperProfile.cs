using AutoMapper;
using SolChargeMeraki.Core.Domain.Entities;
using SolChargeMeraki.Presentaion.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolChargeMeraki.Presentaion.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductEntity, ProductViewModel>().ReverseMap();
        }
    }
}
