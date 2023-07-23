using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;

namespace noon.Application.Services.Mailing_SMS_Service
{
    public class MailService : IMailService
    {
        ////
        /// inject mailsettings configurations to get it's values in appsettings.json
        ////
        private MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile>? attachments )//= null)
        {
         var email = new MimeMessage
         {
            Sender = MailboxAddress.Parse(_mailSettings.Email),
            Subject = subject 

         };
         email.To.Add(MailboxAddress.Parse(mailTo));

         var builder = new BodyBuilder();

         if(attachments != null)
         {
            ////
            /// convert attachments to bytes
            ////
            byte [] fileBytes;
            foreach(var file in attachments)
            {
                if(file.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                    builder.Attachments.Add(file.FileName,fileBytes,ContentType.Parse(file.ContentType));
                }
            }
         }
         else
         {

         builder.HtmlBody = body;
         email.Body = builder.ToMessageBody();
         email.From.Add(new MailboxAddress(_mailSettings.displayName, _mailSettings.Email));


         var smtpClient = new SmtpClient();
         smtpClient.Connect(_mailSettings.Host,_mailSettings.Port, SecureSocketOptions.StartTls);
         smtpClient.Authenticate(_mailSettings.Email, _mailSettings.Password);

         await smtpClient.SendAsync(email);

         smtpClient.Disconnect(true);
         }
        }
    }
}