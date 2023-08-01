using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.OrderServices;
using noon.Domain.Models.Identity;
using System.Security.Claims;

namespace noonDashboard.MVC.Controllers
{
    [Authorize(Roles = "store ")]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemServices orderItem;
        private readonly UserManager<AppUser> userManager;

        public OrderItemController(IOrderItemServices orderItem , UserManager<AppUser> userManager)
        {
            this.orderItem = orderItem;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            var data = orderItem.GetAllOrderProductForStore(user.Id);
            return View(data);
        }
    }
}
