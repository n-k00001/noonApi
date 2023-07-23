using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.BasketDTO
{
    public class UserBasketForUpdateDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItemForUpdateDto> Items { get; set; }

    }
}
