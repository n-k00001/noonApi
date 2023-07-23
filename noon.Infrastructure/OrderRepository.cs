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
    public class OrderRepository : Repositoy<Order, Guid>, IOrderRepository
    {
        private readonly noonContext noonContext;

        public OrderRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }
    }
}
