namespace STM.Services.Services
{
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Configuration;
    using MimeKit;
    using STM.DataTranferObjects.Email;
    using STM.Services.IServices;

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(
            IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public bool SendMail(EmailInfoDto emailInfo)
        {
            try
            {
                var host = this._configuration["Email:Host"];
                var port = !string.IsNullOrEmpty(this._configuration["Email:Port"])
                    ? Convert.ToInt32(this._configuration["Email:Port"])
                    : 0;
                var username = this._configuration["Email:Username"];
                var password = this._configuration["Email:Password"];
                var displayName = this._configuration["Email:DisplayName"];

                if (!emailInfo.EmailAddress.Any())
                {
                    return false;
                }

                if (string.IsNullOrEmpty(host)
                    || string.IsNullOrEmpty(username)
                    || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                var builder = new BodyBuilder
                {
                    HtmlBody = emailInfo.Content,
                };

                var message = new MimeMessage
                {
                    Subject = emailInfo.Title,
                    Body = builder.ToMessageBody(),
                    Sender = new MailboxAddress(displayName, username),
                };

                foreach (var item in emailInfo.EmailAddress)
                {
                    message.To.Add(MailboxAddress.Parse(item));
                }

                using var smtpClient = new SmtpClient
                {
                    CheckCertificateRevocation = false,
                };
                smtpClient.Connect(host, port);
                smtpClient.Authenticate(username, password);
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
