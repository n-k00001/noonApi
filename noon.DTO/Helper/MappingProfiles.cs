using AutoMapper;
using noon.Domain.Models.Order;
using noon.Domain.Models;
using noon.DTO.BasketDTO;
using noon.Domain.Models.Identity;
using noon.DTO.OrderDTO;
using noon.DTO.ProductDTO;
using noon.DTO.UserPaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noon.DTO.UserDTO;


namespace noon.DTO.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<ProductBrand, ProductBrandDTO>().ReverseMap();
            CreateMap<Product, AddEditProductDto>().ReverseMap();
            CreateMap<ProductDto, AddEditProductDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ForMember(dest => dest.images, opt => opt
            .MapFrom(src => src.images.Select(i => i.ImgURL).ToList()))
            .ForMember(dest => dest.reviews, opt => opt
            .MapFrom(src => src.reviews.Select(i => i.Comments).ToList()))
            .ForMember(d => d.brand, o => o.MapFrom(s => s.brand.name))
            .ForMember(d => d.category, o => o.MapFrom(s => s.category.name))
            .ForMember(d => d.AppUser, o => o.MapFrom(s => s.AppUser.DisplayName))
            .ReverseMap();

            CreateMap<ProductBrand, ProductBrandDTO>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();
            CreateMap<ProductCategory, ProductCatogryDetailsDTO>()
                .ForMember(d => d.parentCategory, o => o.MapFrom(s => s.parentCategory.name)).ReverseMap();
            CreateMap<BasketItem, BasketItemForUpdateDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<UserBasket, UserBasketForUpdateDto>().ReverseMap();
            CreateMap<UserBasket, UserBasketDto>().ReverseMap();

            CreateMap<UserPaymentMethod, CreateOrUpdateUserpaymentDto>().ReverseMap();
            CreateMap<UserPaymentMethod, GetAllUserPaymentMethodDto>().ReverseMap();
            CreateMap<UserReview, UserReviewDTO>().ReverseMap();
            CreateMap<AppUser, ProfileDTO>().ReverseMap();

            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<Order,OrderDTO.OrderDTO>().ReverseMap();
            CreateMap<OrderItem,OrderItemDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemForStoreDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
        }
    }
}
