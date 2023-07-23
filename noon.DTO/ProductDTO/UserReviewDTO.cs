using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class UserReviewDTO
    {
        public int id { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool isDeleted { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId {get; set;}
    }
}