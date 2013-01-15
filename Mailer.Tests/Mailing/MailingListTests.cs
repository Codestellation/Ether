using Codestellation.Mailer.Mailing;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests.Mailing
{
    [TestFixture]
    public class MailingListTests
    {
        private MailingList _list;

        [SetUp]
        public void Setup()
        {
            _list = new MailingList("alice@localhost",
                                    "bob@localhost",
                                    "alice@localhost",
                                    "carol@localhost");
        }

        [Test]
        public void CtorTest()
        {
            Assert.That(_list, Is.EquivalentTo(new[]
                {
                    "alice@localhost",
                    "bob@localhost",
                    "carol@localhost"
                }));
        }

        [Test]
        public void Should_make_distinct_union()
        {
            var another = new MailingList("bob@localhost",
                                          "dave@localhost");
            _list.UnionWith(another);

            Assert.That(_list, Is.EquivalentTo(new[]
                {
                    "alice@localhost",
                    "bob@localhost",
                    "carol@localhost",
                    "dave@localhost"
                }));
        }
    }
}