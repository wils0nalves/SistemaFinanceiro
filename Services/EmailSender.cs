using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("yuri.tinocoalves@gmail.com", "lyijhrcwuwssebhh"),
            EnableSsl = true
        };

        var message = new MailMessage
        {
            From = new MailAddress("yuri.tinocoalves@gmail.com", "Sistema Financeiro"),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        message.To.Add(email);

        await smtp.SendMailAsync(message);
    }
}