using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace BlazorServer2
{
    public class MailKitSender : IEmailSender
    {
        private readonly Microsoft.Extensions.Hosting.IHostEnvironment _enviroment;

        public MailKitSender(IOptions<MailKitEmailSenderOptions> options, IHostEnvironment hostEnvironment)
        {
            this.Options = options.Value;
            this._enviroment = hostEnvironment;
        }

        public MailKitEmailSenderOptions Options { get; set; }

        public enum EmailType
        {
            subscribe,
            unsubscribe,
            sharePost
        }

        public Task SendEmailAsync(string email, string subject, string message, EmailType emailType)
        {
            return Execute(email, subject, message, emailType);
        }

        public Task Execute(string to, string subject, string message, EmailType emailType)
        {
            // check type
            if (emailType == EmailType.subscribe)
                message = GetSubscribedHtml();
            else if (emailType == EmailType.unsubscribe)
                message = GetUnSubscribedHtml();
            else if (emailType == EmailType.sharePost)
                message = GetSharedPosHtml(message);

            // create message
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(Options.Sender_EMail);
            if (!string.IsNullOrEmpty(Options.Sender_Name))
                email.Sender.Name = Options.Sender_Name;
            email.From.Add(email.Sender);
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };

            // send email
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(Options.Host_Address, Options.Host_Port, Options.Host_SecureSocketOptions);
                smtp.Authenticate(Options.Host_Username, Options.Host_Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            return Task.FromResult(true);
        }

        // get html to show shared post, customize the same html
        private string GetSharedPosHtml(string postHtmlContent)
        {
            string pathRoot = _enviroment.ContentRootPath;
            string fullPath = System.IO.Path.Combine(pathRoot, @"Data\HtmlSubscribedTemplate.html");
            var owners = System.IO.File.ReadAllLines(fullPath);

            string retMessage = string.Join(Environment.NewLine, owners);

            // replace "TEXT_HERE" with message we want
            retMessage = retMessage.Replace("TEXT_HERE", postHtmlContent);

            return retMessage;
        }

        // html to show this (TODO: should probe select unsubscribed in db (bit value))
        private string GetUnSubscribedHtml()
        {
            string pathRoot = _enviroment.ContentRootPath;
            string fullPath = System.IO.Path.Combine(pathRoot, @"Data\HtmlSubscribedTemplate.html");
            var owners = System.IO.File.ReadAllLines(fullPath);

            string retMessage = string.Join(Environment.NewLine, owners);

            // replace "TEXT_HERE" with message we want
            retMessage = retMessage.Replace("TEXT_HERE", "You've been unsubscribed; hope to meet again soon!");

            return retMessage;
        }

        // get html for subscribed person (TODO: add their email to database in new table)
        private string GetSubscribedHtml()
        {
            string pathRoot = _enviroment.ContentRootPath;
            string fullPath = System.IO.Path.Combine(pathRoot, @"Data\HtmlSubscribedTemplate.html");
            var owners = System.IO.File.ReadAllLines(fullPath);

            string retMessage = string.Join(Environment.NewLine, owners);

            // replace "TEXT_HERE" with message we want
            retMessage = retMessage.Replace("TEXT_HERE", "You have Subscribed! 🥳");

            return retMessage;
        }
    }

    public class MailKitEmailSenderOptions
    {
        public MailKitEmailSenderOptions()
        {
            Host_SecureSocketOptions = SecureSocketOptions.Auto;
        }

        public string Host_Address { get; set; }

        public int Host_Port { get; set; }

        public string Host_Username { get; set; }

        public string Host_Password { get; set; }

        public SecureSocketOptions Host_SecureSocketOptions { get; set; }

        public string Sender_EMail { get; set; }

        public string Sender_Name { get; set; }
    }
}
