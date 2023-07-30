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
        public Task<ProductBrandDTO> GetDetails(int id);
        public Task<IQueryable<ProductBrandDTO>> GetAllBrand();
        public List<ProductBrandDTO> GetAll();
    }
}
