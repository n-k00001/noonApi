using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.AdreessServices;
using noon.Application.Services.UserAddressServices;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressServices userAddressServices;

        public UserAddressController(IUserAddressServices userAddressServices)
        {
            this.userAddressServices = userAddressServices;
        }

        [HttpGet]
        [Route("{UserId}")]
        public async Task<IActionResult> GetAll(string userId)
        {
            var property = await userAddressServices.GetAllUserAddressesAsync(userId);
            return Ok(property);
        }
        [HttpGet]
         [HttpGet("default/{UserId}")]
        public async Task<IActionResult> GetDefualtAddress(string userId)
        {
            var property = await userAddressServices.getDefualtAddress(userId);
            return Ok(property);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var property = await userAddressServices.GetUserAddressByIdAsync(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAddressDTO property)
        {
            try
            {
                var address = await userAddressServices.AddUserAddressAsync(property);
                return Created("", address);
            }
            catch
            {
                return StatusCode(500, "Cant' create");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(UserAddressDTO property)
        {
            var brand = await userAddressServices.UpdateUserAddressAsync(property);
            return Ok(brand);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(userAddressServices.DeleteUserAddressAsync(Id));
        }

    }
}
