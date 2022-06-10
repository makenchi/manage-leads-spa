using MailKit.Net.Smtp;
using MailKit.Security;
using ManageLeadsDomain.Entities;
using ManageLeadsDomainCore.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainServices
{
    public class ServiceEmail : IServiceEmail
    {
        private readonly IConfiguration _config;

        public ServiceEmail(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> SendEmailAsync(Email emailRequest)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(emailRequest.To));
            email.Subject = emailRequest.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailRequest.Body};

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);            

            return await smtp.SendAsync(email);
        }

    }
}
