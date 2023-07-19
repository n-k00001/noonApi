using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.OrderDTO
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public string userId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public AddressDTO? ShipToAddress { get; set; }
        public int paymentMethodId { set; get; }
        public int DeliveryMethodId { get; set; }
        public IReadOnlyList<OrderItemDTO> Items { get; set; }
    }
}
