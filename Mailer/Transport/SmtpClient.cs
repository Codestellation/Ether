using System;
using System.Net.Mail;
using System.Threading;
using Codestellation.Mailer.Core;
using NLog;

namespace Codestellation.Mailer.Transport
{
    public class SmtpClient : ISmtpClient
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public void Send(Email email)
        {
            ThreadPool.QueueUserWorkItem(SendNext, email);
        }

        void SendNext(object state)
        {
            Email email = (Email) state;
            try
            {
                SendNextInternal(email);
            }
            catch (Exception error)
            {
                Log.ErrorException(string.Format("E-mail '{0}' sending failed", email.Subject), error);
            }
        }

        void SendNextInternal(Email email)
        {
            using (var client = new System.Net.Mail.SmtpClient())
            {
                using (var mail = new MailMessage(email.From,
                                                  email.Recepients.Collect(),
                                                  email.Subject,
                                                  email.Body)
                                      {
                                          IsBodyHtml = true
                                      })
                {
                    client.Send(mail);
                }
            }
        }
    }
}