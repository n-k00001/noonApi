using AutoMapper;
using noon.Application.Contract;
using noon.Domain.Contract;
using noon.Domain.Models.Order;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IRepository<DeliveryMethod, int> repository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IRepository<DeliveryMethod,int> repository) 
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.repository = repository;
        }


        public async Task<OrderDTO> Create(OrderDTO propertyDTO)
        {
            var order = mapper.Map<Order>(propertyDTO);
            await orderRepository.CreateAsync(order);
            return propertyDTO;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await orderRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<OrderDTO>> GetAllOrderForUser(string UserId)
        {
            var orders = (await orderRepository.GetAllAsync()).Where(o => o.userId == UserId);
            return orders.Select(o => mapper.Map<OrderDTO>(o));
        }

        public async Task<OrderDTO> GetById(Guid id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            return mapper.Map<OrderDTO>(order);
        }

        public async Task<IQueryable<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<OrderDTO> GetDetails(Guid id)
        {
            var order = await orderRepository.GetDetailsAsync(id);
            return mapper.Map<OrderDTO>(order);
        }

    }
}
