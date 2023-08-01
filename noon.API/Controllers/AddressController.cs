using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.AdreessServices;
using noon.Application.Services.ProductBrandServices;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices addressServices;

        public AddressController(IAddressServices addressServices)
        {
            this.addressServices = addressServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var property = await addressServices.GetAllAddressesAsync();
            return Ok(property);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {           
            var property = await addressServices.GetAddressByIdAsync(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressDTO property)
        {
            try
            {
                var address = await addressServices.AddAddressAsync(property);
                return  Created("", address);
            }
            catch
            {
                return StatusCode(500, "Cant' create");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(AddressDTO property)
        {
            var brand = await addressServices.UpdateAddressAsync(property);
            return Ok(brand);
        }



        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(addressServices.DeleteAddressAsync(Id));
        }

    }
}
