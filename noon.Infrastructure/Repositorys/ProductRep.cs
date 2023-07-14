using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using noon.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure.Repositorys
{
    public class ProductRep : GenericRepository<Product, Guid> ,IProductRep
    {
        public ProductRep(noonContext context) : base(context)
        {
        }
    }
}
