using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Contract;
using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class OrderItemRepository : Repositoy<OrderItem, int>, IOrderItemRepository
    {
        private readonly noonContext noonContext;

        public OrderItemRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }       
    }
}
