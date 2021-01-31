using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Services.Authentication
{
    public class EmailService
    {
        public Task Execute(string UserEmail,string Body,string Subject)
        {
            SmtpClient Client = new SmtpClient();
            Client.Port = 587;
            Client.Host = "smtp.gmail.com";
            Client.EnableSsl = true;
            Client.Timeout = 1000000;
            Client.DeliveryMethod = SmtpDeliveryMethod.Network;
            Client.UseDefaultCredentials = false;
            Client.Credentials = new NetworkCredential("mohsenr2020@gmail.com","8211456109");
            MailMessage message = new MailMessage("mohsenr2020@gmail.com", UserEmail, Subject, Body);
            message.IsBodyHtml = true;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            Client.Send(message);
            return Task.CompletedTask;
        }
    }
}
