using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests.Core
{
    [TestFixture]
    public class MailingListBrokerTests
    {
        [Test]
        [TestCase(typeof(Int32), new[] { "alice@test.ru", "carol@test.ru", "dan@test.ru" })]
        [TestCase(typeof(String), new[] { "alice@test.ru", "carol@test.ru", "bob@test.ru" })]
        public void Should_return_email_recepients_based_on_email_type(Type type, string[] expectedRecepients)
        {
            var broker = new MailingListBroker(new[]
                {
                    new MailingRule("System", MailingList.Create("alice@test.ru", "carol@test.ru")),
                    new MailingRule("System.String", MailingList.Create("alice@test.ru", "bob@test.ru")),
                    new MailingRule("System.Int32", MailingList.Create("alice@test.ru", "dan@test.ru"))
                });

            var recepients = broker.GetRecepients(type);
            Assert.That(recepients, Is.EquivalentTo(new MailingList(expectedRecepients)));
        }
    }
}