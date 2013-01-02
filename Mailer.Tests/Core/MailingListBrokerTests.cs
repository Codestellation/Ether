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
            var broker = new MailingListBroker();
            broker.Register("System",
                            "alice@test.ru", "carol@test.ru");
            broker.Register("System.String",
                            "alice@test.ru", "bob@test.ru");
            broker.Register("System.Int32",
                            "alice@test.ru", "dan@test.ru");

            var recepients = broker.GetRecepients(type);
            Assert.That(recepients, Is.EquivalentTo(expectedRecepients));
        }

        [Test]
        [TestCase("*")]
        [TestCase("Codestellation")]
        [TestCase("Codestellation.*")]
        [TestCase("Codestellation.Mailer")]
        [TestCase("Codestellation.Mailer.*")]
        [TestCase("Codestellation.Mailer.MailNotifier")]
        [TestCase("Codestellation.Mailer.MailNotifier.*")]
        public void IsTypeInHierarchy_should_return_true_if_type_included_in_hierarchy(string hierarchy)
        {
            Assert.That(MailingListBroker.IsTypeInHierarchy(typeof (MailNotifier), hierarchy), Is.True);
        }

        [Test]
        [TestCase("System")]
        [TestCase("System.*")]
        [TestCase("Codestellation.Mail")]
        [TestCase("Codestellation.Mail.*")]
        [TestCase("Codestellation.Mailer.Mail")]
        [TestCase("Codestellation.Mailer.Mail.*")]
        [TestCase("Codestellation.Mailer.MailNotifier.Core")]
        [TestCase("Codestellation.Mailer.MailNotifier.Core.*")]
        public void IsTypeInHierarchy_should_return_false_if_type_not_included_in_hierarchy(string hierarchy)
        {
            Assert.That(MailingListBroker.IsTypeInHierarchy(typeof(MailNotifier), hierarchy), Is.False);
        }
    }
}