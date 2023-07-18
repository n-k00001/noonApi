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
             var model = BackgroundJob.Enqueue(()=>userService.UpdateUser(profile)) ;
           
            return Ok(model);
            }
        }

//        [HttpPut("/{Id}/password")]
//        public async Task<IActionResult> UpdatePassword(string Id, string currntPassword, string newPassword)
// {
//     bool isMatched = await userService.ValidatePassword(Id, currntPassword);
//     if (isMatched)
//     {
//          userService.UpdateUserPassword(newPassword, Id);
//         Console.WriteLine("Password updated successfully for {0}", Id);
//         return Ok();
//     }
//     else
//     {
//         Console.WriteLine("Password is not matched for {0}", Id);
//         return Unauthorized();
//     }
// }


[HttpPut("{Id}/Password")]
public async Task<IActionResult> UpdatePassword(string id, string currentPassword, string newPassword)
{

   //{ var password = await userService.GetPasswordById(id);
    // var user = await userService.GetProfileById(id);
    // if (password == null)
    // {
    //     return NotFound();
    // }

    // var passwordHasher = new PasswordHasher<PasswordDTO>();
    // var passwordVerificationResult = passwordHasher.VerifyHashedPassword(password, password.PasswordHash, currentPassword);

    // if (passwordVerificationResult != PasswordVerificationResult.Success)
    // {
    //     return BadRequest("Invalid password");
    // }

     // password.PasswordHash = passwordHasher.HashPassword(password, newPassword);

    //  userService.ValidatePassword(id, currentPassword);
     userService.UpdateUserPassword(id, newPassword,currentPassword);

    return Ok();
}



        // public async Task<IActionResult> UpdatePassword(string Id , string currntPassword, string newPassword)
        // {
        //     bool isMatched = await userService.ValidatePassword(Id,newPassword);
        //     if(isMatched)
        //     {

        //         var model = BackgroundJob.Enqueue(()=>userService.UpdateUserPassword(newPassword,Id));
        //         Console.WriteLine("Password updated successfully for {0}",Id);
        //         return Ok(model);

        //     }
        //     else
        //     {
        //     Console.WriteLine("Password is not matched for {0}",Id);

        //         return NoContent();
        //     }
           
        // }


    

    }
}