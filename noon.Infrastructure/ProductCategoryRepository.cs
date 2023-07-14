using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public override async Task<ProductCategory> GetDetailsAsync(int id)
        {
            return noonContext.ProductCategorys.Include(a => a.products).ThenInclude(x => x.images).FirstOrDefault(c => c.id == id);
        }
    }

}
