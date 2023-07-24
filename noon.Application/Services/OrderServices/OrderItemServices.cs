using AutoMapper;
using noon.Application.Contract;
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
    }
}
