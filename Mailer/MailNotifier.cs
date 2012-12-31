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

        public MailNotifier(string fromAddress, ISmtpClient smtpClient, IMailingListBroker mailingListBroker)
        {
            _fromAddress = fromAddress;
            _smtpClient = smtpClient;
            _mailingListBroker = mailingListBroker;
        }

        public void Send(object mail)
        {
            Type mailType = mail.GetType();

            var email = new Email(_fromAddress,
                                  _mailingListBroker.GetRecepients(mailType));

            _smtpClient.Send(email);
        }
    }
}
