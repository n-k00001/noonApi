using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.BasketDTO
{
    public class UserBasketDto
    {
        public int Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
