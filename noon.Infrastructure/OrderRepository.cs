using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace noon.Infrastructure
{
    public class OrderRepository : Repositoy<Order, Guid>, IOrderRepository
    {
        private readonly noonContext noonContext;

        public OrderRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }
        public override async Task<Order> GetDetailsAsync(Guid id)
        {

            var order = await noonContext.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.OrderId == id);
            return order;

        }
        public override async Task<IQueryable<Order>> GetAllAsync()
        {
            return  noonContext.Orders.Include(o => o.Items);
        }
    }
}
