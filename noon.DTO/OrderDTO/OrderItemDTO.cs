using noon.Domain.Models.Order;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noon.DTO.ProductDTO;

namespace noon.DTO.OrderDTO
{
    public class OrderItemDTO
    {
        public int id { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto product { get; set; }
        public Guid orderId { get; set; }
        public decimal totalPrice { get => Quantity * product.price; }
        public int Quantity { get; set; }
    }
}
