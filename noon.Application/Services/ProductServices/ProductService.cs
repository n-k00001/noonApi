using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using noon.Application.Contract;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace noon.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRep productRep;
        private readonly IMapper mapper;

        public ProductService(IProductRep productRep , IMapper mapper)
        {
            this.productRep = productRep;
            this.mapper = mapper;
        }

        public ProductDto GetById(Guid id)
        {
            var product = productRep.GetById(id);
            var model = mapper.Map<ProductDto>(product);
            return model;
        }

        public async Task<List<ProductDto>> GetAllPropertyPagination(int Items, int PageNumber)
        {
            var product = await productRep.GetAllAsync();
            var PaginationList = product.Skip(Items * (PageNumber - 1)).Take(Items).Select(a => a).ToList();
            var model = mapper.Map<List<ProductDto>>(PaginationList);
            return model;
        }

        public List<ProductDto> GetAll(int Items, int PageNumber)
        {
            var product = productRep.GetAll();
            var PaginationList = product.Skip(Items * (PageNumber - 1)).Take(Items).Select(a => a).ToList();
            var model = mapper.Map<List<ProductDto>>(PaginationList);
            return model;
        }

        public async Task<AddEditProductDto> Create(AddEditProductDto AddEditProductDto)
        {

            var data = mapper.Map<Product>(AddEditProductDto);

            await productRep.CreateAsync(data);

            await productRep.SaveChanges();
            return AddEditProductDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            await productRep.DeleteAsync(id);
            await productRep.SaveChanges();
            return true;
        }


        public async Task<AddEditProductDto> Update(AddEditProductDto AddEditProductDto)
        {
            if (AddEditProductDto.sku != null)
            {
                var data = mapper.Map<Product>(AddEditProductDto);
                await productRep.UpdateAsync(data);
                await productRep.SaveChanges();
                return AddEditProductDto;

            }
            else
            {
                return AddEditProductDto;
            }
        }

        public async Task<List<ProductDto>> SearchByProductName(string ProductName)
        {
            var product = await productRep.SearchByProductNameAsync(ProductName);
            var model = mapper.Map<List<ProductDto>>(product);
            return model;
        }
    }
}
