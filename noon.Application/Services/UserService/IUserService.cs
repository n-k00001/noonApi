using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.Domain.Models.Identity;
using noon.DTO.UserDTO;
using noon.DTO.UserPaymentDto;

namespace noon.Application.Services.UserService
{
    public interface IUserService
    {
        public Task<List<GetAllUserPaymentMethodDto>> getPaymentsAsync(string userId);

        // public Task<List<ProfileDTO>> GetAllPropertyPagination(int Items, int PageNumber);
        public Task<ProfileDTO> GetProfileById(string id);

        public  Task<ProfileDTO> UpdateUser(ProfileDTO profile, AppUser appUser);

        public Task UpdateUserPassword(string email, string password, string currentPassword);


    }
}
