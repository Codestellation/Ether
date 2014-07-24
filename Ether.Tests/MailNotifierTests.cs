using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Misc;
using Codestellation.Ether.Templating;
using NUnit.Framework;

namespace Codestellation.Ether.Tests
{
    [TestFixture]
    public class MailNotifierTests
    {
        private TestEmailSender _sender;
        private MailNotifier _notifier;

        [SetUp]
        public void Setup()
        {
            _sender = new TestEmailSender();
            var outgouingQueue = new TransientQueue();
            var mailingListBroker = new TestMailingListBroker().Register<string>("alice@test.ru", "bob@test.ru");
            var templateEngine = new MailTemplateEngine();
            templateEngine.Register<string>(m => new MailView(string.Format("Subject for {0}", m),
                                                               string.Format("Body for {0}!", m)));
            
            _notifier = new MailNotifier("me@test.ru", outgouingQueue, mailingListBroker, templateEngine, _sender);
        }

        [TearDown]
        public void Teardown()
        {
            _notifier.Dispose();
        }

        [Test]
        public void Should_send_email()
        {
            _notifier.Send("Hello");
            Email email = _sender.GetNextOutgoing();
            Assert.That(email, Is.Not.Null);
        }

        [Test]
        public void Should_set_email_from_address()
        {
            _notifier.Send("Hello");
            Email email = _sender.GetNextOutgoing();
            Assert.That(email.From, Is.EqualTo("me@test.ru"));
        }

        [Test]
        public void Should_set_email_recepients_depends_on_message_type()
        {
            _notifier.Send("Hello");
            Email email = _sender.GetNextOutgoing();
            Assert.That(email.Recipients, Is.EquivalentTo(new[] { "alice@test.ru", "bob@test.ru" }));
        }

        [Test]
        public void Should_set_email_subject_and_body_using_template()
        {
            _notifier.Send("email");
            Email email = _sender.GetNextOutgoing();
            Assert.That(email.Subject, Is.EqualTo("Subject for email"));
            Assert.That(email.Body, Is.EqualTo("Body for email!"));
        }
    }
}