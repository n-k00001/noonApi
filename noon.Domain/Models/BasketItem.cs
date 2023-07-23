using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class BasketItem
    {
        public int id { get; set; }
        [ForeignKey("userBasket")]
        public int BasketId { get; set; }
        public virtual UserBasket userBasket { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
       // public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
