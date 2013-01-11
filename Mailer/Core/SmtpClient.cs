using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public class SmtpClient : ISmtpClient
    {
        public void Send(Email email)
        {
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient())
            {
                var mail = new MailMessage(email.From,
                                           email.Recepients.Collect(),
                                           email.Subject,
                                           email.Body)
                {
                    IsBodyHtml = true
                };

                client.Send(mail);
            }
        }
    }
}