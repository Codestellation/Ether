using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;
using Codestellation.Mailer.Mailing;
using Codestellation.Mailer.Templating;
using Codestellation.Mailer.Transport;

namespace Codestellation.Mailer
{
    public class MailNotifier : IMailNotifier
    {
        private readonly string _fromAddress;
        private readonly ISmtpClient _smtpClient;
        private readonly IMailingListBroker _mailingListBroker;
        private readonly IMailTemplateEngine _templateEngine;


        public MailNotifier(string fromAddress, ISmtpClient smtpClient, IMailingListBroker mailingListBroker, IMailTemplateEngine templateEngine)
        {
            _fromAddress = fromAddress;
            _smtpClient = smtpClient;
            _mailingListBroker = mailingListBroker;
            _templateEngine = templateEngine;
        }

        public void Send(object mail)
        {
            Type mailType = mail.GetType();
            MailView view = _templateEngine.Render(mail);
            var email = new Email(_fromAddress,
                                  _mailingListBroker.GetRecepients(mailType).ToArray(),
                                  view);
                

            _smtpClient.Send(email);
        }
    }
}
