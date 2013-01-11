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
    }
}