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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {   private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        private readonly IMailService _mailService;
        public static string randcode;
        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager,
               ITokenService _tokenService, IMailService mailService, IHttpContextAccessor httpContextAccessor)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            tokenService = _tokenService;
            _mailService = mailService;
               _httpContextAccessor = httpContextAccessor;

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
            
         await userManager.AddToRoleAsync(user,"user");
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
                        var filePath = @"E:\iti\Web Api\apiNew\noonApi\noon.API\Templetes\EmailVertificationTemplate.html";
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
                        var rand = random();
                        randcode =rand;
                      HttpContext.Session.SetString("Random", rand);

                        mailText = mailText.Replace("[username]", user.DisplayName).Replace("[email]", mailRequestDTO.ToEmail).Replace("[rendom]",rand);

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


                 Console.WriteLine(userDTO);


                }


                #endregion
                userDTO.emailValidation= randcode;
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

        

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string id)
        {

          var user = await userManager.FindByIdAsync(id);
          var result = await userManager.DeleteAsync(user);

          return Ok(result);

        }
     

        [Authorize]
        [HttpGet("getCurrentUser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            return Ok(new UserDTO()
            {
                Email = user.Email,
                DisplayName = $"{user.DisplayName}",
                token = await tokenService.CreateToken(user, userManager)
            });
        }

        [HttpGet("checkemail")]
        public async Task<ActionResult> checkemail( string verifyCode) 
        {
            var local = HttpContext.Session.GetString("Random");
            if(verifyCode == local )
            {
                return Ok(verifyCode);
            }
            else
            return NotFound();
        }




    public static string random()
    {

        Random random = new Random();
        int randomNumber = random.Next(0, 999999);
        string formattedNumber = randomNumber.ToString("D6");
        Console.WriteLine(formattedNumber);

        return formattedNumber;
    }


    }


}
