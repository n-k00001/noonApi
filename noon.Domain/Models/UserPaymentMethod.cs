using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using noon.Domain.Models.Identity;

namespace noon.Domain.Models
{
    public class UserPaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string Provider { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public bool IsDefault { get; set; }


        // Other relevant properties
        [ForeignKey("AppUser")]
        public string UserID { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Order.Order> Orders { get; set; }
    }
}
