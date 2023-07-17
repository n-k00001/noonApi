using noon.Domain.Models.Identity;
using noon.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.UserPaymentDto
{
    public class CreateOrUpdateUserpaymentDto
    {
        [Key]
        public int PaymentMethodID { get; set; }
        public string Provider { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public bool IsDefault { get; set; }

        // Other relevant properties
        public string UserID { get; set; }
        //public AppUser AppUser { get; set; }
        //public ICollection<Order.Order> Orders { get; set; }
    }
}
