using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.UserAddressServices
{
    public interface IUserAddressServices
    {
        public Task<UserAddressDTO> GetUserAddressByIdAsync(int userAddressId);
        public Task<IQueryable<UserAddressDTO>> GetAllUserAddressesAsync(string userId);
        public Task<UserAddressDTO> AddUserAddressAsync(UserAddressDTO userAddress);
        public Task<UserAddressDTO> UpdateUserAddressAsync(UserAddressDTO userAddress);
        public Task DeleteUserAddressAsync(int userAddressId);
        public Task<UserAddressDTO> getDefualtAddress(string userAddressId);
    }
}
