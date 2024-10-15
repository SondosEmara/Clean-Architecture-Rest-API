using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Helpers;
using University.Application.Layer.Services.Interfaces;

namespace University.Infrastructure.Layer.External_Services
{
    public class EmailService : IEmaillService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public async Task<string> SendEmailAsync(string email, string message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{message}",
                        TextBody = "wellcome",
                    };
                    var _message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    _message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                    _message.To.Add(new MailboxAddress("testing", email));
                    _message.Subject = "First-Email-Check";
                    await client.SendAsync(_message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
    }
}
