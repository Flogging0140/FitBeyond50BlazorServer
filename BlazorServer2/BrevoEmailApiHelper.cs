using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BlazorServer2
{
    public class BrevoEmailApiHelper
    {
        // what type of email being sent out
        public enum EmailType
        {
            subscribe,
            unsubscribe,
            sharePost,
            postNotification
        }

        // send email, flexibility
        public Task SendEmailAsync(string email, string subject, string message, EmailType emailType)
            => Execute(email, subject, emailType, message);

        // choose type, send with api
        public async Task Execute(string to, string subject, EmailType emailType, string message = "")
        {
            // check mail type
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
            else if (emailType == EmailType.postNotification)
            {
                message = GetNotificationHtml(subject);
                subject = "Sharing Post, FitBeyond50";
            }

            // create message
            var requestData = new
            {
                sender = new { email = "bhanel@gmail.com", name = "FitBeyond50.ca" },
                to = new[] { new { email = to } },
                subject,
                textContent = message
            };

            string jsonString = JsonSerializer.Serialize(requestData);
            StringContent content = new(jsonString, Encoding.UTF8, "application/json");

            // maybe null, if is then that is a problem a dev should fix, customer does not see nasty page
            string? apiKey = System.Environment.GetEnvironmentVariable("SMTP_API_KEY") ?? throw new Exception("ENV var for api-key null");

            // send email
            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("api-key", apiKey);
                HttpResponseMessage response = await httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", content);

                // check was sent successfully
                response.EnsureSuccessStatusCode();
            }
        }

        // our html template doc
        private static string ReadoutHtml()
            => "<!DOCTYPE html><html lang=\"en\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:v=\"urn:schemas-microsoft-com:vml\"><head><title></title><meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\"><meta content=\"width=device-width,initial-scale=1\" name=\"viewport\"><!--[if mso]><xml><o:officedocumentsettings><o:pixelsperinch>96</o:pixelsperinch><o:allowpng></o:officedocumentsettings></xml><![endif]--><style>*{box-sizing:border-box}body{margin:0;padding:0}a[x-apple-data-detectors]{color:inherit!important;text-decoration:inherit!important}#MessageViewBody a{color:inherit;text-decoration:none}p{line-height:inherit}.desktop_hide,.desktop_hide table{mso-hide:all;display:none;max-height:0;overflow:hidden}.image_block img+div{display:none}@media (max-width:720px){.desktop_hide table.icons-inner{display:inline-block!important}.icons-inner{text-align:center}.icons-inner td{margin:0 auto}.image_block img.big,.row-content{width:100%!important}.mobile_hide{display:none}.stack .column{width:100%;display:block}.mobile_hide{min-height:0;max-height:0;max-width:0;overflow:hidden;font-size:0}.desktop_hide,.desktop_hide table{display:table!important;max-height:none!important}.row-2 .column-1 .block-1.image_block td.pad{padding:20px 20px 0!important}.row-2 .column-1 .block-3.paragraph_block td.pad{padding:0 20px!important}.row-2 .column-1 .block-2.heading_block h1{font-size:35px!important}}</style></head><body style=\"background-color:#b0b98e;margin:0;margin-top:25px;padding:0;-webkit-text-size-adjust:none;text-size-adjust:none\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"nl-container\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;background-color:#b0b98e\" width=\"100%\"><tbody><tr><td><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-2\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\" width=\"100%\"><tbody><tr><td><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;background-color:#f8f4e8;border-radius:0;color:#000;width:700px\" width=\"700\"><tbody><tr><td class=\"column column-1\" style=\"mso-table-lspace:0;mso-table-rspace:0;font-weight:400;text-align:left;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0\" width=\"100%\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"image_block block-1\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\" width=\"100%\"><tr><td class=\"pad\" style=\"width:100%;padding-right:0;padding-left:0\"><div align=\"center\" class=\"alignment\" style=\"line-height:10px\"><img alt=\"Fit Beyond 50 Image of Trees\" class=\"big\" src=\"https://images.pexels.com/photos/1423600/pexels-photo-1423600.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\" style=\"display:block;margin-top:15px;height:auto;border:0;width:595px;max-width:100%\" title=\"Hero Image\" width=\"595\"></div></td></tr></table><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"heading_block block-2\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\" width=\"100%\"><tr><td class=\"pad\" style=\"padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:20px;text-align:center;width:100%\"><h1 style=\"margin:0;color:#334259;direction:ltr;font-family:Montserrat,'Trebuchet MS','Lucida Grande','Lucida Sans Unicode','Lucida Sans',Tahoma,sans-serif;font-size:55px;font-weight:700;letter-spacing:normal;line-height:120%;text-align:center;margin-top:0;margin-bottom:0\">Fit Beyond 50<br></h1></td></tr></table><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"paragraph_block block-3\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;word-break:break-word\" width=\"100%\"><tr><td class=\"pad\" style=\"padding-left:60px;padding-right:60px\"><div style=\"color:#334259;direction:ltr;font-family:Arial,'Helvetica Neue',Helvetica,sans-serif;font-size:18px;font-weight:400;letter-spacing:0;line-height:150%;text-align:center;mso-line-height-alt:27px\"><h4 style=\"margin:0;color:#334259;direction:ltr;font-family:Montserrat,'Trebuchet MS','Lucida Grande','Lucida Sans Unicode','Lucida Sans',Tahoma,sans-serif;font-size:35px;font-weight:300;letter-spacing:normal;line-height:120%;text-align:center;margin-top:0;margin-bottom:0\">HEADER_HERE<br></h4><p style=\"margin:0\">TEXT_HERE</p></div></td></tr></table><div class=\"spacer_block block-4\" style=\"height:30px;line-height:30px;font-size:1px\"> </div><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"paragraph_block block-5\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;word-break:break-word\" width=\"100%\"><tr><td class=\"pad\" style=\"padding-bottom:10px;padding-left:20px;padding-right:20px;padding-top:10px\"><div style=\"color:#d79c60;direction:ltr;font-family:Lato,Tahoma,Verdana,Segoe,sans-serif;font-size:16px;font-weight:400;letter-spacing:0;line-height:150%;text-align:center;mso-line-height-alt:24px\"><p style=\"margin:0\"><a href=\"http://www.example.com\" rel=\"noopener\" style=\"text-decoration:underline;color:#d79c60\" target=\"_blank\">Unsubscribe</a></p></div></td></tr></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>";

        // get html to show shared post, customize the same html
        private static string GetSharedPosHtml(string postHtmlContent, string subjectHeader)
             => ReadoutHtml()
            .Replace("TEXT_HERE", postHtmlContent)
            .Replace("HEADER_HERE", subjectHeader);

        // html to show this (TODO: should probe select unsubscribed in db (bit value))
        private static string GetUnSubscribedHtml()
             => ReadoutHtml()
            .Replace("TEXT_HERE", "You've been unsubscribed; hope to meet again soon!")
            .Replace("HEADER_HERE", "Unsubscribed from FitBeyond50.ca");

        // get html for subscribed person (TODO: add their email to database in new table)
        private static string GetSubscribedHtml()
            => ReadoutHtml()
            .Replace("TEXT_HERE", "You have Subscribed! 🥳")
            .Replace("HEADER_HERE", "Subscribed to FitBeyond50.ca");

        // get html email template, 
        private static string GetNotificationHtml(string subjectHeader)
            => ReadoutHtml()
            .Replace("TEXT_HERE", $"A new post has been released! {subjectHeader}, <a href=\"https://fitbeyond50.ca\" rel=\"noopener\" style=\"text-decoration:underline;color:#d79c60\" target=\"_blank\">Checkout FitBeyond50!</a>")
            .Replace("HEADER_HERE", "Post update, FitBeyond50.ca");
    }
}
