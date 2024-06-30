using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Email.Service
{
    public class EmailService : IEmailService
    {
        public void Send()
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "mail.rentachar.com";
            sc.EnableSsl = false;

            sc.Credentials = new NetworkCredential("salih@rentachar.com", "0V1v2sn0!");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("salih@rentachar.com", "ZanDent Randevu Sistemi");

            mail.To.Add("m.salihargun@gmail.com");

            mail.Subject = "Yeni Randevu Alındı"; mail.IsBodyHtml = true; mail.Body = "Yeni Randevu Alındı";

            //Yeni Randevu bilgilerini epostaya ekleme

            sc.Send(mail);
        }
    }
}
