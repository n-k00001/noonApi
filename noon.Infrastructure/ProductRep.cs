using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure.Repositorys
{
    public class ProductRep : Repositoy<Product, Guid> ,IProductRep
    {
        private readonly noonContext context;

        public ProductRep(noonContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Product>> SearchByProductNameAsync(string ProductName)
        {
            return await context.Products
                .Where(a => a.name.ToLower().Contains(ProductName.ToLower()))
                .ToListAsync();
        }
        
    }
}
