using AutoMapper;
using noon.Application.Contract;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.ProductBrandServices
{
    public class ProductBrandServices : IProductBrandServices
    {
        private readonly IProductBrandRepository productBrandRep;
        private readonly IMapper mapper;

        public ProductBrandServices(IProductBrandRepository productBrandRep, IMapper mapper)
        {
            this.productBrandRep = productBrandRep;
            this.mapper = mapper;
        }
        public async Task<ProductBrandDTO> Create(ProductBrandDTO brandDTO)
        {
            var brand = mapper.Map<ProductBrand>(brandDTO);
            await productBrandRep.CreateAsync(brand);
            await productBrandRep.SaveChanges();
            return brandDTO;
        }

        public async Task<bool> Delete(int id)
        {
            return await productBrandRep.DeleteBrand(id);
        }

        public async Task<ProductBrandDTO> GetById(int id)
        {
            var brand = await productBrandRep.GetByIdAsync(id);
            var model = mapper.Map<ProductBrandDTO>(brand);
            return model;
        }

        public async Task<ProductBrandDTO> Update(ProductBrandDTO brandDTO)
            {
            if (brandDTO.id == 0) {
                await Create(brandDTO);
                return brandDTO;
            }
            else
            {
                var model = mapper.Map<ProductBrand>(brandDTO);
                await productBrandRep.UpdateAsync(model);
                productBrandRep.SaveChanges();

                return brandDTO;
            }

        }

        public async Task<ProductBrandDTO> GetDetails(int id)
        {
            var brand = await productBrandRep.GetDetailsAsync(id);
            var model = mapper.Map<ProductBrandDTO>(brand);
            return model;
        }
        public async Task<IQueryable<ProductBrandDTO>> GetAllBrand()
        {
            var brand = await productBrandRep.GetAllAsync();
            return brand.Select(item => mapper.Map<ProductBrandDTO>(item));

        }

        public List<ProductBrandDTO> GetAll()
        {
            var brand = productBrandRep.GetAll();

            var data = mapper.Map<List<ProductBrandDTO>>(brand);
            return data;
        }
    }
}
