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