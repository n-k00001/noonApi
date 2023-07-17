using AutoMapper;
using noon.Application.Contract;
using noon.Domain.Models.Identity;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.AdreessServices
{
    public class AddressServices : IAddressServices
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public AddressServices(IAddressRepository addressRepository, IMapper mapper) 
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async Task<AddressDTO> AddAddressAsync(AddressDTO address)
        {
            var model = mapper.Map<Address>(address);
            await addressRepository.CreateAsync(model);
            return address;
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            await addressRepository.DeleteAsync(addressId);
        }

        public async Task<AddressDTO> GetAddressByIdAsync(int addressId)
        {
            var model = await addressRepository.GetByIdAsync(addressId);
            return mapper.Map<AddressDTO>(model);
        }

        public async Task<IQueryable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await addressRepository.GetAllAsync();
            return addresses.Select(item => mapper.Map<AddressDTO>(item));
        }

        public async Task<AddressDTO> UpdateAddressAsync(AddressDTO address)
        {
            var model = mapper.Map<Address>(address);
            await addressRepository.UpdateAsync(model);
            return address;
        }
    }
}
