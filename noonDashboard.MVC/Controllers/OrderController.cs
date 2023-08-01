using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.OrderServices;
using noon.Application.Services.ProductServices;
using noon.Domain.Models;
using noon.DTO.OrderDTO;
using noon.DTO.ProductDTO;
using System.Security.Claims;

namespace noonDashboard.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            var data = orderService.GetAllOrderForAdmin();

            return View(data);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = orderService.GetByIdForAdmin(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(OrderUpdateDto orderUpdateDto)
        {
            if (ModelState.IsValid)
            {

                orderService.Update(orderUpdateDto);
                return RedirectToAction("index");
            }
            return View(orderUpdateDto);
        }
    }
}
