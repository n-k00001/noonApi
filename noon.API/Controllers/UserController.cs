using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.UserService;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

    private readonly IUserService userService;

    public UserController(IUserService _userService)
    {
        this.userService = _userService;
    }
    [HttpGet]
    [Route("{id}")]
     public async Task<IActionResult> GetProfileByID(string id)
        {
            // 11111111-2222-3333-4444-555555555555
            var property = await userService.GetById(id);
            return Ok(property);
        }

    }
}