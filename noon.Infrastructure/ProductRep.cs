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
        public ProductRep(noonContext context) : base(context)
        {
        }
    }
}
