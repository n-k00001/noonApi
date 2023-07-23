using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.Application.Services.Mailing_SMS_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using noon.DTO.Mail;
using Hangfire;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailingController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailingController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("sendmail")]
        public async Task<IActionResult> SendMail([FromForm] MailRequestDto mailRequestDTO)
        {

             var filePath = $"{Directory.GetCurrentDirectory()}//Templetes//EmailVertificationTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[username]", "Abdelrahman").Replace("[email]",mailRequestDTO.ToEmail );

          await  _mailService.SendEmailAsync(mailRequestDTO.ToEmail,mailRequestDTO.Subject, mailRequestDTO.Body);

            return Ok(mailRequestDTO);
        }


        //   [HttpPost("welcome")]
        // public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequestDto dto)
        // {
        //     var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\EmailTemplate.html";
        //     var str = new StreamReader(filePath);

        //     var mailText = str.ReadToEnd();
        //     str.Close();

        //     mailText = mailText.Replace("[username]", dto.UserName).Replace("[email]", dto.Email);

        //     await _mailingService.SendEmailAsync(dto.Email, "Welcome to our channel", mailText);
        //     return Ok();
        // }
    }
}