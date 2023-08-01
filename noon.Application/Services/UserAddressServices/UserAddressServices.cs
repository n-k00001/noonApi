using AutoMapper;
using Hangfire.Annotations;
using noon.Application.Contract;
using noon.Domain.Models.Identity;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.UserAddressServices
{
    public class UserAddressServices : IUserAddressServices
    {
        private readonly IUserAddressRepository userAddressRepository;
        private readonly IMapper mapper;

        public UserAddressServices(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            this.userAddressRepository = userAddressRepository;
            this.mapper = mapper;
        }

        public async Task<UserAddressDTO> AddUserAddressAsync(UserAddressDTO userAddress)
        {

            Guid guid=  Guid.NewGuid();
            // var model = mapper.Map<UserAddress>(userAddress);
            var model = new UserAddress(){
                Id= guid.ToString(),
                AddressID=userAddress.AddressID,
                userId= userAddress.userId,
                 isDefualt= userAddress.isDefualt,
            };
            await userAddressRepository.CreateAsync(model);
            return userAddress;
        }

        public async Task DeleteUserAddressAsync(int userAddressId)
        {
            await userAddressRepository.DeleteAsync(userAddressId);
        }

        public async Task<IQueryable<UserAddressDTO>> GetAllUserAddressesAsync(string userId)
        {
            var model = await userAddressRepository.GetAllAsync();
            var all = model.Where(u => u.userId == userId);
            return all.Select(item => mapper.Map<UserAddressDTO>(item));
        }

        public async Task<UserAddressDTO> getDefualtAddress(string userAddressId)
        {
            var model = await userAddressRepository.GetAllAsync();
            var defualt = model.FirstOrDefault(d => d.userId == userAddressId&& d.isDefualt == true);
            return mapper.Map<UserAddressDTO>(defualt);
        }

        public async Task<UserAddressDTO> GetUserAddressByIdAsync(int userAddressId)
        {
            var useradd = await userAddressRepository.GetByIdAsync(userAddressId);
            return mapper.Map<UserAddressDTO>(useradd);
        }

        public async Task<UserAddressDTO> UpdateUserAddressAsync(UserAddressDTO userAddress)
        {
            var model = mapper.Map<UserAddress>(userAddress);
            await userAddressRepository.UpdateAsync(model);
            return userAddress;
        }
    }
}
