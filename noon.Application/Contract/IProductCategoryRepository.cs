using noon.Domain.Contract;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        Task<IEnumerable<ProductCategory>> FilterByAsync(string filter, int id);
        IQueryable<ProductCategory> GetAll();
        ProductCategory GetbyId(int id);
    }
}
