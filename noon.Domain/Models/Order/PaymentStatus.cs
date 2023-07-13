using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Order
{
    public enum PaymentStatus
    {
        /// Pending
        Pending = 10,


        /// Authorized
        Authorized = 20,


        /// Paid
        Paid = 30,


        /// Partially Refunded
        PartiallyRefunded = 35,


        /// Refunded
        Refunded = 40,


        /// Voided
        Voided = 50
    }
}
