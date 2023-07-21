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
            };

            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user.");
            }

            var userDTO = new UserDTO()
            {
                Email = registerDTO.Email,
                DisplayName = user.DisplayName,
                token =  await tokenService.CreateToken(user, userManager)
            };

            #region send Mail
            if (result.Succeeded)
            {
               
         

                    var filePath = $"{Directory.GetCurrentDirectory()}//Templates//EmailVerificationTemplate.html";

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
                    mailText,
                mailRequestDTO.Attachments);
                    Console.WriteLine("Mail sending Success to {0}", mailRequestDTO.ToEmail);
            



                }

            
                //                "displayName": "Abdelrahman",
                //  "firstName": "Abdelrahamn",
                //  "lastName": "Mohamed",
                //  "email": "abdo.mohamed6319@gmail.com",
                //  "phoneNumber": "+201017696026",
                //  "password": "D3bes63##",
                //  "userAddresses": null
                //}

                #endregion

                return Ok(userDTO);
            }
        }

    }