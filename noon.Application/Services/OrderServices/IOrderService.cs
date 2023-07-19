using noon.Domain.Models.Order;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.OrderServices
{
    public interface IOrderService
    {
        public Task<OrderDTO> Create(OrderDTO propertyDTO);
        public Task<OrderDTO> GetById(Guid id);
        public Task<bool> Delete(Guid id);
        Task<OrderDTO> GetDetails(Guid id);
        Task<IQueryable<OrderDTO>> GetAllOrderForUser(string UserId);
        Task<IQueryable<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
