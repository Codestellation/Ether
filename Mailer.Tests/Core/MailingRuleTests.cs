using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests.Core
{
    [TestFixture]
    public class MailingRuleTests
    {
        [Test]
        public void Should_contain_unique_recepients()
        {
            var rule = new MailingRule("*", "alice@localhost", "bob@localhost", "alice@localhost");
            Assert.That(rule.Recepients, Is.EquivalentTo(new[] { "alice@localhost", "bob@localhost" }));
        }

        [Test]
        [TestCase("*")]
        [TestCase("Codestellation")]
        [TestCase("Codestellation.*")]
        [TestCase("Codestellation.Mailer")]
        [TestCase("Codestellation.Mailer.*")]
        [TestCase("Codestellation.Mailer.MailNotifier")]
        [TestCase("Codestellation.Mailer.MailNotifier.*")]
        public void Check_should_return_true_if_type_included_in_hierarchy(string hierarchy)
        {
            var rule = new MailingRule(hierarchy);
            Assert.That(rule.Check(typeof (MailNotifier)), Is.True);
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
        public void Check_should_return_false_if_type_not_included_in_hierarchy(string hierarchy)
        {
            var rule = new MailingRule(hierarchy);
            Assert.That(rule.Check(typeof(MailNotifier)), Is.False);
        }
    }
}