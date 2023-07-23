using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noon.DTO.UserDTO
{
    public class PasswordDTO
    {
        public string PasswordHash { get; set; }
        public string? Password_UN_Hashed { get; set; }
    }
}