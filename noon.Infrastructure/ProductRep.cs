using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

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
                .Where(a => a.name.ToLower().Contains(ProductName.ToLower())).Include(p => p.images).Include(b => b.brand)
                .Include(b => b.category).Include(b => b.store).Include(b => b.reviews)
            .ToListAsync();
        }

        public List<Product> GetAll()
        {

            return  context.Products.Include(p => p.images).Include(b => b.brand)
                .Include(b => b.category).Include(b => b.store).Include(b => b.reviews).ToList();


        }

        public Product GetById(Guid id)
        {
            return context.Products.Include(p => p.images).Include(b => b.brand)
                .Include(b => b.category).Include(b => b.store).Include(b => b.reviews)
                .FirstOrDefault(p => p.sku == id);
        }
    }
}
