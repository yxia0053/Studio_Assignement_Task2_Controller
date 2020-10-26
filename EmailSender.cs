using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FIT5032_Week08A.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void SendAsync(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("17602377780@163.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes("E:\\5032email\\confirm.docx");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("confirm.dox", file);
            var response = client.SendEmailAsync(msg);
        }

        internal Task SendAsync(string toEmail)
        {
            throw new NotImplementedException();
        }

        internal Task SendAsync(string toEmail, string body)
        {
            throw new NotImplementedException();
        }
    }
}