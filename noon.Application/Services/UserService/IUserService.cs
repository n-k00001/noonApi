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

    public  Task<PasswordDTO> GetPasswordById(string id);
     public  void  UpdateUserPassword(string password ,string id,string currentPassword);

     public  Task<bool> ValidatePassword(string id,string password_UN_Hashed);

    }
}