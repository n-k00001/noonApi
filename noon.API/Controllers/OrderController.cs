using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.OrderServices;
using noon.Domain.Models.Order;
using noon.DTO.OrderDTO;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService) 
        {
            this.orderService = orderService;
        }
        [HttpGet]
        [Route("UserOrders/{UserId}")]
        public async Task<IActionResult> GetAll(string UserId)
        {
            var property = await orderService.GetAllOrderForUser(UserId);
            return Ok(property);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var property = await orderService.GetDetails(id);
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

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(string Id)
        {
            Console.WriteLine(Id);
            Guid hh = new Guid() ;
            bool isDeleted = await orderService.Delete(hh);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await orderService.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }
    }
}
