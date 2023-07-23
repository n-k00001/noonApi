using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using noon.Domain.Models.Identity;
using noon.DTO.UserDTO;
using noon.Application.Contract;
using noon.DTO.Mail;
using noon.Application.Services.Mailing_SMS_Service;
using noon.Domain.Models.Order;
using noon.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        private readonly IMailService _mailService;

        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager,
               ITokenService _tokenService, IMailService mailService)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            tokenService = _tokenService;
            _mailService = mailService;

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return Unauthorized();
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded) return Unauthorized();



            return Ok(new UserDTO()
            {
                Email = loginDTO.Email,
                DisplayName = user.DisplayName,
                token = await tokenService.CreateToken(user, userManager)
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

                // UserAddresses = new List<UserAddress>(),
                // Orders = new List<Order>(),
                // paymentMethods = new List<UserPaymentMethod>()
            };

            var result = await userManager.CreateAsync(user,registerDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user.");
            }

            try
            {
                var userDTO = new UserDTO()
                {
                    Email = registerDTO.Email,
                    DisplayName = user.DisplayName,
                    token = await tokenService.CreateToken(user, userManager)
                };


                #region send Mail
                if (result.Succeeded)
                {


                    try
                    {
                        //var filePath = @"\EmailVertificationTemplate.html";
                        var filePath = @"/noon.API/Templetes/EmailVertificationTemplate.html" ;
                        string mailText;
                        using (var str = new StreamReader(filePath))
                        {
                            mailText = await str.ReadToEndAsync();
                        }

                        MailRequestDto mailRequestDTO = new MailRequestDto()
                        {
                            ToEmail = user.Email,
                            Subject = "test",
                            Body = mailText,


                        };

                        mailText = mailText.Replace("[username]", user.DisplayName).Replace("[email]", mailRequestDTO.ToEmail);

                        await _mailService.SendEmailAsync(

                    mailRequestDTO.ToEmail,
                    mailRequestDTO.Subject,
                        mailText);
                        Console.WriteLine("Mail sending Success to {0}", mailRequestDTO.ToEmail);

                    }
                    catch
                    {
                        MailRequestDto mailRequestDTO = new MailRequestDto()
                        {
                            ToEmail = user.Email,
                            Subject = "Ecommerce",
                            Body = "welcome to ecommerce team",


                        };

                        await _mailService.SendEmailAsync( mailRequestDTO.ToEmail, mailRequestDTO.Subject,   mailRequestDTO.Body);
                        await Console.Out.WriteLineAsync("can't send mail with html body");
                    }





                }


                #endregion

                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                var userDTO = new UserDTO()
                {
                    Email = registerDTO.Email,
                    DisplayName = user.DisplayName,
                    token = await tokenService.CreateToken(user, userManager)
                };
                await Console.Out.WriteLineAsync("can't send mail" + ex.Message);

                return Ok(userDTO);


            }



           
        }



    }

}
