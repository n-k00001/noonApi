using AutoMapper;
using noon.Application.Contract;
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

        public async Task<ProductDto> GetById(Guid id)
        {
            var product = await productRep.GetByIdAsync(id);
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
        public Task<ProductDto> Create(ProductDto propertyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<ProductDto> Update(ProductDto propertyDTO)
        {
            throw new NotImplementedException();
        }
    }
}
