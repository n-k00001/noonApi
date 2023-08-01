using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.OrderDTO
{
    public class OrderUpdateDto
    {
        public Guid OrderId { get; set; }
        public string userId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int? ShipToAddressId { get; set; }
        public ShippingStatus? ShippingStatus { get; set; }
        public int? PaymentIntentId { set; get; }
        public PaymentStatus? PaymentStatus { set; get; }
        public int DeliveryMethodId { get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
        public OrderStatus? Status { get; set; }
        public List<OrderItemDTO>? Items { get; set; }
    }
}
