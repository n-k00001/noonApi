using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Contract;
using noon.Domain.Models;
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
        public async Task<IQueryable<OrderItem>> GetAllItemForOrderAsync(Guid orderId)
        {
           return (await GetAllAsync()).Where(o => o.orderId == orderId);
        }

        //public List<OrderItem> GetAll(Guid orderId)
        //{
        //    var data = noonContext.OrderItems.Include(a => a.Product).ToList();
        //    var model = data.Where(o => o.orderId == orderId);
        //    return (List<OrderItem>)model;
        //}


        //public override Task<IQueryable<OrderItem>> GetAllAsync()
        //{
        //    var data = noonContext.OrderItems.Include(a => a.Product);
        //    return (Task<IQueryable<OrderItem>>)data;
        //}

        public List<OrderItem> GetAll()
        {
            return noonContext.OrderItems.Include(a => a.Product).ToList();
        }
    }
}
