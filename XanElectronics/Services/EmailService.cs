using MailKit.Net.Smtp;
using MimeKit;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XanElectronics.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(List<string> email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Education Saytin Admini", "javiddadashov8@mail.ru"));
            foreach (var item in email)
            {
                emailMessage.To.Add(new MailboxAddress("", item));
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("c.cavid123.d@mail.ru", "IA2UoIuory6_");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
