using courier.management.system.Extensions;
using courier.management.system.Services.Interface;
using MailKit.Net.Smtp;
using MimeKit;

namespace courier.management.system.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly ILoggerManager _logger;
        AppConfiguration config = new AppConfiguration();
        //private readonly string Footer;
        private readonly string Header;
        private readonly string Checkout;
        private readonly string Info;
        private const string SubjectAz = "Bildiriş";
        private const string From = "BillKill";

        public EmailService(ILoggerManager logger)
        {
            _logger = logger;
            string MailTemplated = Path.GetFullPath(config.AppFilePath);
            if (Directory.Exists(MailTemplated))
            {
                //Footer = System.IO.File.ReadAllText(System.IO.Path.Combine(MailTemplated, "footer.html"));
                Header = System.IO.File.ReadAllText(System.IO.Path.Combine(MailTemplated, "header.html"));
                Checkout = System.IO.File.ReadAllText(System.IO.Path.Combine(MailTemplated, "checkout.html"));
                Info = System.IO.File.ReadAllText(System.IO.Path.Combine(MailTemplated, "info.html"));
            }
        }

        public bool SendEmailForgetPassword(string userMail, string token)
        {
            string message = String.Empty;
            message = $"Bu <a href=\"{token}\">linkə</a> keçid edərək, şifrəni yeniləyə bilərsiniz.";
            message = CreateMainContent(message);
            return SendEmailAsync(userMail, From, SubjectAz, message).Result;
        }

        //Helper
        public string CreateMainContent(string content)
        {
            string info = String.Format(Info, content);
            string footer = String.Empty;
            //footer = Footer;

            string mainContent = string.Format(Checkout, Header, info, footer);
            mainContent = mainContent.Replace("\r\n", "");
            return mainContent;
        }

        public async Task<bool> SendEmailAsync(string email, string from, string subject, string content)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(from, config.MailUsername));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = content;
                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(config.MailHost, config.MailPort, false);
                    await client.AuthenticateAsync(config.MailUsername, config.MailPassword);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                _logger.LogInfo($"Successfully sent an email: {email}");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($", System error: {nameof(SendEmailAsync)}: " + $"{e}");
                return false;
            }
        }
    }
}
