using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using noon.Domain.Models.Identity;
using noon.DTO.UserDTO;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)  return Unauthorized( );
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)  return Unauthorized( );
            return Ok(new UserDTO()
            {
                Email = loginDTO.Email,
                DisplayName = user.DisplayName,
                token ="temp token"
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
             var user = new AppUser()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email.Split("@")[0],
                DisplayName = registerDTO.DisplayName,
                PhoneNumber = registerDTO.PhoneNumber,
              
            };

               var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded) return BadRequest( );
            var userDTO = new UserDTO()
            {
                Email = registerDTO.Email,
                DisplayName = $"{user.DisplayName}",
                token = "temp token"
                // token = await _tokenService.CreateToken(user, userManager)
            };
            return Ok(userDTO);
        }
    }

}
