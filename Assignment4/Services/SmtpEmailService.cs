using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using VisitorSecuritySys.Interface;
using Microsoft.Extensions.Options;

namespace VisitorSecuritySys.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public SmtpEmailService(IOptions<SmtpSettings> smtpSettings)
        {
            var settings = smtpSettings.Value;
            _fromEmail = settings.FromEmail;
            _smtpClient = new SmtpClient(settings.Host, settings.Port)
            {
                Credentials = new NetworkCredential(settings.Username, settings.Password),
                EnableSsl = settings.EnableSsl
            };
        }

        public async Task SendEmailAsync(string to, string subject, string message)
        {
            var mailMessage = new MailMessage(_fromEmail, to, subject, message)
            {
                IsBodyHtml = true
            };

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
