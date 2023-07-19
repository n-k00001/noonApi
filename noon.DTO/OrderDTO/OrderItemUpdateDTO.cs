using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.OrderDTO
{
    public class OrderItemUpdateDTO
    {
        public int id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
