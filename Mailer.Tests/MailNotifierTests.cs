using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests
{
    [TestFixture]
    public class MailNotifierTests
    {
        [Test]
        public void Should_send_email_using_smtpclient()
        {
            var smtpClient = new TestSmtpClient();
            var notifier = new MailNotifier(smtpClient);
            notifier.Send("Hello");
            Assert.That(smtpClient.GetNextOutgoing(), Is.Not.Null);
        }
    }
}
