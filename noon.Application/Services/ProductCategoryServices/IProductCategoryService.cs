using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace noon.Application.Services.ProductCategoryServices
{
    public interface IProductCategoryService
    {
        public Task<ProductCategoryDTO> CreateAsync(ProductCategoryDTO category);
        public Task<ProductCategoryDTO> GetByIdAsync(int Id);
        public Task<IQueryable<ProductCategoryDTO>> GetAllAsync();
        public Task<ProductCategoryDTO> UpdateAsync(ProductCategoryDTO category);
        public Task<bool> DeleteAsync(int Id);
        public Task<ProductCategoryDTO?> GetDetailsAsync(int id);
        public List<ProductCatogryDetailsDTO> GetAll();
        public ProductCatogryDetailsDTO GetById(int id);
    }
}
