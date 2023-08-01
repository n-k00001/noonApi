using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.OrderDTO
{
    public class OrderItemForStoreDto
    {
        public int id { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto product { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
