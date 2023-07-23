using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noon.DTO.UserDTO
{
    public class ProfileDTO
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
    }
}