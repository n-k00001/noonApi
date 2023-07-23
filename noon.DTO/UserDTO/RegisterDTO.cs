using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using noon.Domain.Models.Identity;

namespace noon.DTO.UserDTO
{
    public class RegisterDTO
    {
         [Required]
        public string DisplayName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
           ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]

        public string Password { get; set; }
        
        public List<UserAddress>? UserAddresses { get; set; }
        // [Required]
        // public string City { get; set; }
        // [Required]
        // public string Country { get; set; }
        // [Required]
        // public string Street { get; set; }
        // [Required]
        // public string ZipCode { get; set; }
    }
}