using AutoMapper;
using noon.Application.Contract;
using noon.DTO.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.OrderServices
{
    public class OrderItemServices : IOrderItemServices
    {
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IMapper mapper;

        public OrderItemServices(IOrderItemRepository orderItemRepository, IMapper mapper) 
        {
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
        }

        public List<OrderItemForStoreDto> GetAllOrderProductForStore(string UserId)
        {
            var orderItem = orderItemRepository.GetAll();
            var filterOrderItem = orderItem.Where(a => a.Product.userId == UserId);
            var model = mapper.Map<List<OrderItemForStoreDto>>(filterOrderItem);
            return model;
        }

        //public async Task<IQueryable<OrderItemForStoreDto>> GetAllOrderProductForStore(string UserId)
        //{
        //    var orderItem = await orderItemRepository.GetAllAsync();
        //    var filterOrderItem = orderItem.Where(a => a.Product.userId == UserId);
        //    //var model = mapper.Map< IQueryable<OrderItemForStoreDto>>(filterOrderItem);
        //    return filterOrderItem.Select(a=>mapper.Map<OrderItemForStoreDto>(a));
        //}


    }
}
