using System;
using System.Threading.Tasks;
using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Misc;
using Codestellation.Ether.Templating.Razor;
using Codestellation.Ether.Tests.Templating.Razor;
using NUnit.Framework;

namespace Codestellation.Ether.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {
        private MailNotifier _notifier;
        private TestEmailSender _sender;

        [SetUp]
        public void Setup()
        {
            _sender = new TestEmailSender();
            var outgouingQueue = new PersistentQueue(Guid.NewGuid().ToString("n"));
            var mailingListBroker = new MailingListBroker(new[]
            {
                new MailingRule("*", new MailingList("alice@localhost"))
            });
            var templateEngine = new RazorMailTemplateEngine(new RazorTemplatesFactory("Resources"), true);

            _notifier = new MailNotifier(
                "me@localhost",
                outgouingQueue,
                mailingListBroker,
                templateEngine,
                _sender);
        }

        [TearDown]
        public void Teardown()
        {
            _notifier.Dispose();
        }

        [Test]
        public void Should_send_email()
        {
            _notifier.Send(new Baz());

            var email = _sender.GetNextOutgoing();
            Assert.That(email, Is.Not.Null);
            Assert.That(email.From, Is.EqualTo("me@localhost"));
            Assert.That(email.Recipients, Is.Not.Empty);
            Assert.That(email.Subject, Is.Not.Empty);
            Assert.That(email.Body, Is.Not.Empty);
        }

        [Test]
        public void Should_send_emails()
        {
            const int count = 1000;
            var t1 = new Task(() =>
            {
                for (int i = 0; i < count; i++)
                    _notifier.Send(new Baz());
            });
            var t2 = new Task(() =>
            {
                for (int i = 0; i < count; i++)
                    _notifier.Send(new Foo());
            });
            var t3 = new Task(() =>
            {
                for (int i = 0; i < count; i++)
                    _notifier.Send(new Bar());
            });
            t1.Start();
            t2.Start();
            t3.Start();
            Task.WaitAll(t1, t2, t3);

            for (int i = 0; i < 3*count; i++)
            {
                Email email = _sender.GetNextOutgoing();
                Assert.That(email, Is.Not.Null);
            }
        }
    }
}