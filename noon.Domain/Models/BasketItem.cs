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
        public int id { set; get; }
        [ForeignKey("userBasket")]
        public int basketId { set; get; }
        public UserBasket userBasket { set; get; }  
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal totalPrice { set => totalPrice = Quantity * Product.price; }
        public int Quantity { get; set; }
    }
}
