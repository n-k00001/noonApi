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

     public Task<ProfileDTO> UpdateUser(string Id, ProfileDTO profile);

         public Task<PasswordDTO> UpdateUserPassword(PasswordDTO password);

    }
}