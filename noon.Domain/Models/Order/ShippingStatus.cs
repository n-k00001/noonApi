using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Order
{
    public enum ShippingStatus
    {
        /// Shipping not required
        ShippingNotRequired = 10,


        /// Not yet shipped
        NotYetShipped = 20,


        /// Partially shipped
        PartiallyShipped = 25,


        /// Shipped
        Shipped = 30,


        /// Delivered
        Delivered = 40
    }
}
