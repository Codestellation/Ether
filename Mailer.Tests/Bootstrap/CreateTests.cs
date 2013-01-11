using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Bootstrap;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests.Bootstrap
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void Should_create_mailnotifier_from_appconfig_file()
        {
            IMailNotifier notifier = Create
                .MailNotifier()
                .FromConfig()
                .Build();

            Assert.That(notifier, Is.Not.Null);
        }
    }
}
