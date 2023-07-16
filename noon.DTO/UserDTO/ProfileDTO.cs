using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noon.DTO.UserDTO
{
    public class ProfileDTO
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberConfirmed { get; set; }
    }
}