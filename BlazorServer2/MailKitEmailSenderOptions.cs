using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorServer2
{
    public class MailKitSender/* : IEmailSender*/
    {
        private readonly Microsoft.Extensions.Hosting.IHostEnvironment _enviroment;
        private readonly HttpClient _httpClient = new HttpClient();

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

        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    return Execute(email, subject, message, emailType);
        //}

        public async Task Execute(string to, string subject, string message, EmailType emailType)
        {
            // check type
            if (emailType == EmailType.subscribe)
            {
                message = GetSubscribedHtml();
                subject = "Subscribed, FitBeyond50";
            }

            else if (emailType == EmailType.unsubscribe)
            {
                message = GetUnSubscribedHtml();
                subject = "Unsubscribed, FitBeyond50";
            }
            else if (emailType == EmailType.sharePost)
            {
                message = GetSharedPosHtml(message, subject);
                subject = "Sharing Post, FitBeyond50";
            }

            // create message

            var requestData = new
            {
                sender = new { email = Options.Sender_EMail, name = Options.Sender_Name },
                to = new[] { new { email = to } },
                subject,
                textContent = message
            };

            var jsonString = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            string apiKey = System.Environment.GetEnvironmentVariable("SMTP_API_KEY"); 

            // send email
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("api-key", apiKey);
                //httpClient.DefaultRequestHeaders.Add("", Options.Host_Password);
                var response = await httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", content);

                response.EnsureSuccessStatusCode();
            }







            //var email = new MimeMessage();
            //email.Sender = MailboxAddress.Parse(Options.Sender_EMail);
            //if (!string.IsNullOrEmpty(Options.Sender_Name))
            //    email.Sender.Name = Options.Sender_Name;
            //email.From.Add(email.Sender);
            //email.To.Add(MailboxAddress.Parse(to));
            //email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = message };

            //// send email
            //using (var smtp = new SmtpClient())
            //{
            //    smtp.Connect(Options.Host_Address, Options.Host_Port, Options.Host_SecureSocketOptions);
            //    smtp.Authenticate(Options.Host_Username, Options.Host_Password);
            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}

            //return Task.FromResult(true);
        }

        // read out the html into lines
        private string ReadoutHtml()
        {
            string pathRoot = _enviroment.ContentRootPath;
            string fullPath = System.IO.Path.Combine(pathRoot, @"Data\HtmlSubscribedTemplate.html");
            var owners = System.IO.File.ReadAllLines(fullPath);
            return string.Join(/*Environment.NewLine*/"", owners);
        }

        // get html to show shared post, customize the same html
        private string GetSharedPosHtml(string postHtmlContent, string subjectHeader)
             => ReadoutHtml()
            .Replace("TEXT_HERE", postHtmlContent)
            .Replace("HEADER_HERE", subjectHeader);

        // html to show this (TODO: should probe select unsubscribed in db (bit value))
        private string GetUnSubscribedHtml()
             => ReadoutHtml()
            .Replace("TEXT_HERE", "You've been unsubscribed; hope to meet again soon!")
            .Replace("HEADER_HERE", "Unsubscribed from FitBeyond50.ca");

        // get html for subscribed person (TODO: add their email to database in new table)
        private string GetSubscribedHtml()
            => ReadoutHtml()
            .Replace("TEXT_HERE", "You have Subscribed! 🥳")
            .Replace("HEADER_HERE", "Subscribed to FitBeyond50.ca");
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
