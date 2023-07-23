using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Identity
{
    public class UserAddress
    {
        public string Id { get; set; }
        public bool isDefualt { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
