using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class UserAddressDTO
    {
        public string Id { get; set; }
        public bool isDefualt { get; set; }
        
        //public AddressDTO Address { get; set; }
        public int AddressID { set; get; }
        public string userId { get; set; }
    }
}
