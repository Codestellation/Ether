using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Templating;
using NUnit.Framework;

namespace Codestellation.Ether.Tests
{
    [TestFixture]
    public class MailNotifierTests
    {
        private InMemoryOutgoingEmailQueue _outgoingQueue;
        private TestMailingListBroker _mailingListBroker;
        private MailTemplateEngine _templateEngine;
        private MailNotifier _notifier;

        [SetUp]
        public void Setup()
        {
            _outgoingQueue = new InMemoryOutgoingEmailQueue();
            _mailingListBroker = new TestMailingListBroker().Register<string>("alice@test.ru", "bob@test.ru");
            _templateEngine = new MailTemplateEngine();
            _templateEngine.Register<string>(m => new MailView(string.Format("Subject for {0}", m),
                                                               string.Format("Body for {0}!", m)));

            _notifier = new MailNotifier("me@test.ru", _outgoingQueue, _mailingListBroker, _templateEngine);
        }

        [TearDown]
        public void Teardown()
        {
            _notifier.Dispose();
        }

        [Test]
        public void Should_send_email_using_smtpclient()
        {
            _notifier.Send("Hello");
            Email email = _outgoingQueue.GetNextOutgoing();
            Assert.That(email, Is.Not.Null);
        }

        [Test]
        public void Should_set_email_from_address()
        {
            _notifier.Send("Hello");
            Email email = _outgoingQueue.GetNextOutgoing();
            Assert.That(email.From, Is.EqualTo("me@test.ru"));
        }

        [Test]
        public void Should_set_email_recepients_depends_on_message_type()
        {
            _notifier.Send("Hello");
            Email email = _outgoingQueue.GetNextOutgoing();
            Assert.That(email.Recipients, Is.EquivalentTo(new string[] {"alice@test.ru", "bob@test.ru"}));
        }

        [Test]
        public void Should_set_email_subject_and_body_using_template()
        {
            _notifier.Send("email");
            Email email = _outgoingQueue.GetNextOutgoing();
            Assert.That(email.Subject, Is.EqualTo("Subject for email"));
            Assert.That(email.Body, Is.EqualTo("Body for email!"));
        }
    }
}