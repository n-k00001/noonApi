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
using Microsoft.AspNetCore.Authorization;
namespace noon.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

         private readonly IUserService userService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager ;
       

    public UserController(IUserService _userService,UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
    {
          userService = _userService;
         signInManager = _signInManager;
            userManager = _userManager;
    }
        [HttpGet("profile")]
         public async Task<IActionResult> GetProfileByEmail(string email)
        {
            var property = await userService.GetProfileByEmail(email);
            return Ok(property);
        }

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(string email, [FromBody] ProfileDTO profile)
        {

            // var obj = await userService.GetProfileById(Id);
            var appUser = await userManager.FindByEmailAsync(email);
            try
            {
                if (appUser == null)
                {
                    return NotFound("User not found  : " + email);
                }
                else
                {
                    var model = userService.UpdateUser(profile, appUser);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Profile Update failed"+ex.Message);
            }
        }



        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> ChangePassword(string email, string currentPassword, string newPassword)
        {

              //userService.UpdateUserPassword(email, newPassword,currentPassword);

                 var appUser = await userManager.FindByEmailAsync(email);
            var ValidatePassword = await userManager.CheckPasswordAsync(appUser, currentPassword);

            if (ValidatePassword)
            {
                var result = await userManager.ChangePasswordAsync(appUser, currentPassword, newPassword);
                if (!result.Succeeded)
                {
                    
                    
                    return BadRequest("Update password failed");
                }

            }
            
                Console.WriteLine("Update password successful");
                 return Ok();

            

        }


        [HttpPut("UpdatePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber(string email, string newPhoneNumber)
        {
            var appUser = await userManager.FindByEmailAsync(email);
         
            var token = await userManager.GenerateChangePhoneNumberTokenAsync(appUser, newPhoneNumber);
            var verify = userManager.VerifyChangePhoneNumberTokenAsync(appUser,token,newPhoneNumber);

            var result = await userManager.ChangePhoneNumberAsync(appUser, newPhoneNumber,token);
            return Ok(result);
        }


        [HttpPut("UpdateEmail")]
        public async Task<IActionResult> ChangeEmail(string email, string newEmail)
        {

            var appUser = await userManager.FindByEmailAsync(email);

            var token = await userManager.GenerateChangeEmailTokenAsync(appUser, newEmail);

            var result = await userManager.ChangeEmailAsync(appUser, newEmail,token);

            return Ok(result);

        }

         [HttpPost("Payment")]
         public async Task<IActionResult> GetPayment(string UserId)
         {

            var Payments = await userService.getPaymentsAsync(UserId);
            return Ok(Payments);
         }






    }
}