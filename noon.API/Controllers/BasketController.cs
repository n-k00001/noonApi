using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.Basket;
using noon.DTO.BasketDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("/basket")]
        public async Task<IActionResult> GetBasket()
        {
            var basket = await _basketService.GetBasketByUserIdAsync(User.Identity.Name);
            return Ok(basket);
        }

        [HttpPut("/basket")]
        public async Task<IActionResult> UpdateBasket([FromBody] UserBasketForUpdateDto basketDto)
        {
            await _basketService.UpdateBasketAsync(basketDto);
            return NoContent();
        }
    }
}
