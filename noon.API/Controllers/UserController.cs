using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.UserService;
using noon.DTO.UserDTO;

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
            var property = await userService.GetProfileById(id);
            return Ok(property);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProfile(string Id,[FromBody]ProfileDTO profile)
        {
            
            var obj = userService.GetProfileById(Id);

             if (obj == null) {
                return NotFound("User not found id : "+Id);
            }
            else
            {
             var model = BackgroundJob.Enqueue(()=>userService.UpdateUser(Id,profile)) ;
           
            return Ok(model);
            }
        }
    

    }
}