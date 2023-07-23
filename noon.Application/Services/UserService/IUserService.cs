using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.DTO.UserDTO;

namespace noon.Application.Services.UserService
{
    public interface IUserService
    {
        // public Task<List<ProfileDTO>> GetAllPropertyPagination(int Items, int PageNumber);
        public Task<ProfileDTO> GetProfileById(string id);

     public Task<ProfileDTO> UpdateUser(ProfileDTO profile);

        public Task UpdateUserPassword(string email, string password, string currentPassword);


    }
}
