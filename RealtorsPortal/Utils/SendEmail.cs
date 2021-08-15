using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace RealtorsPortal.Utils
{
    public static class SendEmail
    {
        public static void Notification (string receiver, string subject, string message)
        {
            try
            {
                if(!String.IsNullOrEmpty(receiver))
                {
                    var senderEmail = new MailAddress(SystemConstant.EMAIL_ADMIN, SystemConstant.NAME);
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "12345678a@";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                }
            }
            catch (Exception )
            {
                
            }
        }

    }
}