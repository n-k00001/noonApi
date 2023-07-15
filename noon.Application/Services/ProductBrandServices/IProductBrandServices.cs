using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.ProductBrandServices
{
    public interface IProductBrandServices
    {
        public Task<ProductBrandDTO> Create(ProductBrandDTO propertyDTO);
        public Task<ProductBrandDTO> GetById(int id);
        public Task<ProductBrandDTO> Update(ProductBrandDTO propertyDTO);
        public Task<bool> Delete(int id);
        Task<ProductBrandDTO> GetDetails(int id);
        Task<IQueryable<ProductBrandDTO>> GetAllBrand();
    }
}
