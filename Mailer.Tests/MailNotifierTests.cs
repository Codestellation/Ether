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
        private TestSmtpClient _smtpClient;
        private TestMailingListBroker _mailingListBroker;
        private MailNotifier _notifier;

        [SetUp]
        public void Setup()
        {
            _smtpClient = new TestSmtpClient();
            _mailingListBroker = new TestMailingListBroker().Register<string>("alice@test.ru", "bob@test.ru");
            _notifier = new MailNotifier("me@test.ru", _smtpClient, _mailingListBroker);
        }

        [Test]
        public void Should_send_email_using_smtpclient()
        {
            _notifier.Send("Hello");
            Assert.That(_smtpClient.GetNextOutgoing(), Is.Not.Null);
        }

        [Test]
        public void Should_set_email_from_address()
        {
            _notifier.Send("Hello");
            Email email = _smtpClient.GetNextOutgoing();
            Assert.That(email.From, Is.EqualTo("me@test.ru"));
        }

        [Test]
        public void Should_set_email_recepients_depends_on_message_type()
        {
            _notifier.Send("Hello");
            Email email = _smtpClient.GetNextOutgoing();
            Assert.That(email.Recepients, Is.EquivalentTo(new string[] {"alice@test.ru", "bob@test.ru"}));
        }
    }
}