using noon.Domain.Models.Identity;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.AdreessServices
{
    public interface IAddressServices
    {
        public Task<AddressDTO> GetAddressByIdAsync(int addressId);
        public Task<IQueryable<AddressDTO>> GetAllAddressesAsync();
        public Task<AddressDTO> AddAddressAsync(AddressDTO address);
        public Task<AddressDTO> UpdateAddressAsync(AddressDTO address);
        public Task DeleteAddressAsync(int addressId);
    }
}
