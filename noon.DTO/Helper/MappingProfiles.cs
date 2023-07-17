using AutoMapper;
using noon.Domain.Models;
using noon.Domain.Models.Identity;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();


        }
    }
}
