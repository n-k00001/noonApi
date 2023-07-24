using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.AdminAccountVM
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
