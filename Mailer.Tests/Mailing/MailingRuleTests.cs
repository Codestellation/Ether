using Codestellation.Mailer.Mailing;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests.Mailing
{
    [TestFixture]
    public class MailingRuleTests
    {
        [Test]
        public void CtorTest()
        {
            var list = new MailingList();
            var rule = new MailingRule("*", list);

            Assert.That(rule.TypeHierarchy, Is.EqualTo("*"));
            Assert.That(rule.Recepients, Is.EqualTo(list));
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