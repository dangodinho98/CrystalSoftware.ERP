using CrystalSoftware.ERP.Shared.Configuration;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Repositories.Services
{
    public class MailService : IIdentityMessageService
    {
        private readonly MailSettings _emailSettings;
        public MailService(MailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            using var client = new SmtpClient();
            client.Host = _emailSettings.Host;
            client.Port = _emailSettings.Port;
            client.EnableSsl = _emailSettings.EnableSsl;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailSettings.EmailFrom, _emailSettings.EmailFromPassword);

            //Get the body and from address
            var fromEmailAddress = "default-email@example.com";
            var body = message.Body;

            var from = new MailAddress(fromEmailAddress);
            var to = new MailAddress(message.Destination);

            var mailMessage = new MailMessage(from, to)
            {
                Subject = message.Subject,
                Body = body,
                IsBodyHtml = true,
            };
            await client.SendMailAsync(mailMessage);
        }
    }
}
