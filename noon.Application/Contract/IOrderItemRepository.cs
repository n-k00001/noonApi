using noon.Domain.Contract;
using noon.Domain.Models;
using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IOrderItemRepository : IRepository<OrderItem, int>
    {
        Task<IQueryable<OrderItem>> GetAllItemForOrderAsync(Guid orderId);
        List<OrderItem> GetAll();
        //List<OrderItem> GetAll(Guid orderId);
    }
}
