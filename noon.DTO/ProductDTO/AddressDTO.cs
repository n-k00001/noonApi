using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class AddressDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string fullAddress { get; set; }
        public string phoneNumber { get; set; }
        public enum addressLabel
        {
            work,
            home
        }
    }
}
