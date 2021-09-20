using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XanElectronics.Dto;
using XanElectronics.Models;

namespace XanElectronics.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReturnDto>()
                .ForMember(x => x.Category
                    , o =>
                        o.MapFrom(x => x.Category.Name))
                .ForMember(x => x.ProductImages
                , o =>
                o.MapFrom(x => x.ProductImages.Select(b => b.ImageUrl)));

            CreateMap<Product, ProductUpdateDto>();
        }


    }
}
