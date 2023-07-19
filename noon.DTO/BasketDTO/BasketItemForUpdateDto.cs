using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.BasketDTO
{
    public class BasketItemForUpdateDto
    {

        public int Id { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
