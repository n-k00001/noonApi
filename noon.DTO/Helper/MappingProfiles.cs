using AutoMapper;
using noon.Domain.Models;
using noon.Domain.Models.Identity;
using noon.DTO.ProductDTO;
using noon.DTO.UserPaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noon.DTO.UserDTO;
using noon.Domain.Models.Identity;

namespace noon.DTO.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<ProductBrand, ProductBrandDTO>().ReverseMap();
            CreateMap<ProductCategory,ProductCategoryDTO >().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(d => d.brand, o => o.MapFrom(b => b.brand.name))
                .ForMember(d => d.category, o => o.MapFrom(b => b.category.name))
                .ForMember(d => d.store, o => o.MapFrom(b => b.store.Name)).ReverseMap();

            CreateMap<UserPaymentMethod,CreateOrUpdateUserpaymentDto>().ReverseMap();
            CreateMap<UserPaymentMethod, GetAllUserPaymentMethodDto>().ReverseMap();







            CreateMap<AppUser, ProfileDTO>().ReverseMap();
            CreateMap<AppUser, PasswordDTO>()
            .ForMember(d => d.PasswordHash, o=> o.MapFrom(b => b.PasswordHash)).ReverseMap();

        }
    }
}
