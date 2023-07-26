using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace noon.Infrastructure
{
    public class ProductCategoryRepository : Repositoy<ProductCategory, int>, IProductCategoryRepository
    {
        private readonly noonContext noonContext;
        public ProductCategoryRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }

        public async Task<IEnumerable<ProductCategory>> FilterByAsync(string filter, int id)
        {
            return noonContext.ProductCategorys.Where(a => (a.name.ToLower().Contains(filter.ToLower()) || a.name.Contains(filter)))
                .Where(c => c.parentCategory.id == id);
        }

        public override async Task<IQueryable<ProductCategory>> GetAllAsync()
        {
            return noonContext.ProductCategorys.Include(s => s.childrenCategories);
        }

        public ProductCategory GetbyId(int id)
        {
            var data = noonContext.ProductCategorys.Include(s => s.parentCategory).FirstOrDefault(a => a.id == id);
            return data;
        }

        IQueryable<ProductCategory> IProductCategoryRepository.GetAll()
        {
            var data = noonContext.ProductCategorys.Include(s => s.parentCategory);
            return data;
        }
    }

}
