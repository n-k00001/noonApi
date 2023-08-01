using noon.DTO.OrderDTO;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.OrderServices
{
    public interface IOrderItemServices
    {
        //Task<IQueryable<OrderItemForStoreDto>> GetAllOrderProductForStore(string UserId);
        List<OrderItemForStoreDto> GetAllOrderProductForStore(string UserId);
    }
}
