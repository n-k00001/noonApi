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

             BackgroundJob.Enqueue( () =>  _mailService.SendEmailAsync(mailRequestDTO.ToEmail,mailRequestDTO.Subject, mailRequestDTO.Body,mailRequestDTO.Attachments));

            return Ok(mailRequestDTO);
        }
    }
}