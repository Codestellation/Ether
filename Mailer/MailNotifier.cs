using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;

namespace Codestellation.Mailer
{
    public class MailNotifier : IMailNotifier
    {
        private readonly string _fromAddress;
        private readonly ISmtpClient _smtpClient;
        private readonly IMailingListBroker _mailingListBroker;
        private readonly IMailTemplateConainer _templateConainer;

        public MailNotifier(string fromAddress, ISmtpClient smtpClient, IMailingListBroker mailingListBroker, IMailTemplateConainer templateConainer)
        {
            _fromAddress = fromAddress;
            _smtpClient = smtpClient;
            _mailingListBroker = mailingListBroker;
            _templateConainer = templateConainer;
        }

        public void Send(object mail)
        {
            Type mailType = mail.GetType();

            IMailTemplate template = _templateConainer.Get(mailType);

            string subject, body;
            template.Render(mail, out subject, out body);

            var email = new Email(_fromAddress,
                                  _mailingListBroker.GetRecepients(mailType))
                {
                    Subject = subject,
                    Body = body
                };

            _smtpClient.Send(email);
        }
    }
}
