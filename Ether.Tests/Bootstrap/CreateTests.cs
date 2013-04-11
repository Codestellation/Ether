using Codestellation.Ether.Bootstrap;
using NUnit.Framework;

namespace Codestellation.Ether.Tests.Bootstrap
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void Should_create_mailnotifier_from_config_file()
        {
            IMailNotifier notifier = Create
                .MailNotifier()
                .FromConfig()
                .Build();

            Assert.That(notifier, Is.Not.Null);
        }
    }
}