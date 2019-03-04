using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OAuthWeb.Apps
{
    public class EmailSender
    {

        private string username = "trung.tran@wisky.vn";
        private string password = "muzikmylife4ever";

        public EmailSender()
        {

        }

        public async void SendMailAsync(MailMessage mess)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(username, password);
                smtp.EnableSsl = true;
                mess.From = new MailAddress("TNTCo.Support@xyz.com");
                mess.Sender = new MailAddress("TNTCo.Support@xyz.com");
                await smtp.SendMailAsync(mess);
            }
        }

    }
}
