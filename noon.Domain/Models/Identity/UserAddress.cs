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
        public Address Address { get; set; }
    }
}
