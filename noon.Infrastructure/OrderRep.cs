using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class OrderRep : Repositoy<Order, Guid>, IOrderRep
    {
        public OrderRep(noonContext noonContext) : base(noonContext)
        {
        }
    }
}
