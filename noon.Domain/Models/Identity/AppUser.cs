﻿using Microsoft.AspNetCore.Identity;
using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
        public List<Order.Order> Orders { set; get; }
        public List<UserPaymentMethod> paymentMethods { set; get; }
    }
}