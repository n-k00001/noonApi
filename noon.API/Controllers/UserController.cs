using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.UserService;
using noon.Domain.Models.Identity;
using noon.DTO.UserDTO;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

         private readonly IUserService userService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager ;
       

    public UserController(IUserService _userService,UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
    {
        this.userService = _userService;
         signInManager = _signInManager;
            userManager = _userManager;
    }

        [HttpGet]
        [Route("{id}")]
         public async Task<IActionResult> GetProfileByID(string id)
        {
            var property = await userService.GetProfileById(id);
            return Ok(property);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProfile(string Id, [FromBody] ProfileDTO profile)
        {

            var obj = userService.GetProfileById(Id);

            try
            {
                if (obj == null)
                {
                    return NotFound("User not found id : " + Id);
                }
                else
                {
                    var model = userService.UpdateUser(profile);

                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Profile Update failed"+ex.Message);
            }
        }





  [HttpPut("{Id}/Password")]
public async Task<IActionResult> UpdatePassword(string email, string currentPassword, string newPassword)
{

     userService.UpdateUserPassword(email, newPassword,currentPassword);

    return Ok();
}





    

    }
}