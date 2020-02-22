using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Smtp
{
    public class SmtpGmailManager
    {
        private const string SMTP_ADDR = "smtp.gmail.com";
        private const int PORT = 587;
        private const bool ENABLE_SSL = true;

        private readonly string _email, _password;

        public SmtpGmailManager(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public async Task SendEmail(string toAddress, string subject, string body)
        {
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(_email);
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(SMTP_ADDR, PORT))
                {
                    //smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_email, _password);
                    smtp.EnableSsl = ENABLE_SSL;
                    await smtp.SendMailAsync(mail);
                }
            }
        }

    }
}
