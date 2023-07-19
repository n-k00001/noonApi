using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.OrderServices;
using noon.Domain.Models.Order;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        OrderController(IOrderService orderService) 
        {
            this.orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] string UserId)
        {
            var property = await orderService.GetAllOrderForUser(UserId);
            return Ok(property);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var property = await orderService.GetById(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDTO property)
        {
            try
            {
                var brand = await orderService.Create(property);
                return Created("", brand);
            }
            catch
            {
                return StatusCode(500, "Cant' create");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            return Ok(orderService.Delete(Id));
        }
        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await orderService.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }
    }
}
