using System;
using System.Linq;
using System.Threading;
using Codestellation.Mailer.Core;
using Codestellation.Mailer.Mailing;
using Codestellation.Mailer.Templating;
using Codestellation.Mailer.Transport;
using NLog;

namespace Codestellation.Mailer
{
    public class MailNotifier : IMailNotifier
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly string _fromAddress;
        private readonly ISmtpClient _smtpClient;
        private readonly IMailingListBroker _mailingListBroker;
        private readonly IMailTemplateEngine _templateEngine;


        public MailNotifier(string fromAddress, ISmtpClient smtpClient, IMailingListBroker mailingListBroker, IMailTemplateEngine templateEngine)
        {
            if(string.IsNullOrEmpty(fromAddress))
            {
                throw new ArgumentNullException("fromAddress");
            }
            _fromAddress = fromAddress;
            _smtpClient = smtpClient;
            _mailingListBroker = mailingListBroker;
            _templateEngine = templateEngine;
        }

        public void Send(object mail)
        {
            ThreadPool.QueueUserWorkItem(RenderAndSend, mail);
        }

        void RenderAndSend(object mail)
        {
            try
            {
                Type mailType = mail.GetType();
                MailView view = _templateEngine.Render(mail);
                var email = new Email(_fromAddress,
                                      _mailingListBroker.GetRecepients(mailType).ToArray(),
                                      view);

                _smtpClient.Send(email);
            }
            catch (Exception error)
            {
                Log.ErrorException(string.Format("E-mail '{0}' sending failed", mail), error);
            }
        }
    }
}
