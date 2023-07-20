using AutoMapper;
using noon.Domain.Models.Order;
using noon.Domain.Models;
using noon.DTO.BasketDTO;
using noon.DTO.OrderDTO;
using noon.DTO.ProductDTO;
using noon.DTO.UserPaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noon.Domain.Models.Identity;

namespace noon.DTO.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<ProductBrand, ProductBrandDTO>().ReverseMap();
            CreateMap<Product, AddEditProductDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<ProductBrand, ProductBrandDTO>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemForUpdateDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<UserBasket, UserBasketForUpdateDto>().ReverseMap();
            CreateMap<UserBasket, UserBasketDto>().ReverseMap();

            CreateMap<UserPaymentMethod, CreateOrUpdateUserpaymentDto>().ReverseMap();
            CreateMap<UserPaymentMethod, GetAllUserPaymentMethodDto>().ReverseMap();

            CreateMap<Address,AddressDTO>().ReverseMap();
            CreateMap<UserAddress,UserAddressDTO>().ReverseMap();   

            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Order, OrderDTO.OrderDTO>().ReverseMap();

        }
    }
}
