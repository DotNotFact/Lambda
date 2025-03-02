using Microsoft.Extensions.Configuration;
using MimeKit;
using NETCore.MailKit.Core;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class EmailService(IConfiguration configuration)
    // : IEmailService
{
    private readonly IConfiguration _configuration = configuration;

    //public async Task SendEmailAsync(string email, string subject, string message)
    //{
    //    var mailSettings = _configuration.GetSection("MailSettings");
    //    var emailMessage = new MimeMessage();
    //    emailMessage.From.Add(new MailboxAddress("YourApp", mailSettings["Mail"]);
    //    emailMessage.To.Add(new MailboxAddress(email));
    //    emailMessage.Subject = subject;
    //    emailMessage.Body = new TextPart("plain") { Text = message };

    //    using (var client = new MailKit.Net.Smtp.SmtpClient())
    //    {
    //        await client.ConnectAsync(mailSettings["SmtpHost"], int.Parse(mailSettings["SmtpPort"]), MailKit.Security.SecureSocketOptions.StartTls);
    //        await client.AuthenticateAsync(mailSettings["Mail"], mailSettings["Password"]);
    //        await client.SendAsync(emailMessage);
    //        await client.DisconnectAsync(true);
    //    }
    //}
} 
