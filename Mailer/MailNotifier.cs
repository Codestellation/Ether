using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;

namespace Codestellation.Mailer
{
    public class MailNotifier : IMailNotifier
    {
        private readonly ISmtpClient _smtpClient;

        public MailNotifier(ISmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public void Send(object mail)
        {
            _smtpClient.Send(new Email());
        }
    }
}
