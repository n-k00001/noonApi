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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await _basketService.GetBasketByUserIdAsync(id);
            return Ok(basket);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBasket(UserBasketForUpdateDto basketDto)
        {

            await _basketService.UpdateBasketAsync(basketDto);

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int basketId)
        {
            var result = await _basketService.DeleteBasketAsync(basketId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}

