using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.DTO.UserDTO;

namespace noon.Application.Services.UserService
{
    public interface IUserService
    {
       public Task<ProfileDTO> Create(ProfileDTO propertyDTO);
        // public Task<List<ProfileDTO>> GetAllPropertyPagination(int Items, int PageNumber);
        public Task<ProfileDTO> GetById(string id);
        public Task<ProfileDTO> Update(ProfileDTO propertyDTO);
        public Task<bool> Delete(string id);
    }
}