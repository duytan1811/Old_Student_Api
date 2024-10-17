namespace STM.Services.Services
{
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Configuration;
    using MimeKit;
    using MimeKit.Utils;
    using STM.DataTranferObjects.Email;

    internal class EmailService
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

                if (string.IsNullOrEmpty(emailInfo.EmailAddress))
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

                if (emailInfo.HasAttachment)
                {
                    var image = builder.Attachments.Add(emailInfo.FileName, emailInfo.File);
                    image.ContentId = MimeUtils.GenerateMessageId();
                }

                var message = new MimeMessage
                {
                    Subject = emailInfo.Title,
                    Body = builder.ToMessageBody(),
                    Sender = new MailboxAddress(displayName, username),
                };

                message.To.Add(MailboxAddress.Parse(emailInfo.EmailAddress));

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
