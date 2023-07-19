using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace noon.Application.Services.Mailing_SMS_Service
{
    public interface IMailService
    {
        Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile>? attachments = null);
    }
}