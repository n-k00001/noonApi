using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Order
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        public OrderItem(int quantity)
        {
            Quantity = quantity;
        }
        public int id { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Order")]
        public Guid orderId { get; set; }
        public Order Order { get; set; }
        public decimal totalPrice { get => Quantity * Product.price; }
        public int Quantity { get; set; }
    }
}
