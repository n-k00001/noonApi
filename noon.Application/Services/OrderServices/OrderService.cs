﻿using AutoMapper;
using noon.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.OrderServices
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper) 
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
    }
}
