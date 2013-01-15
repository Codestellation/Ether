using Codestellation.Mailer.Core;
using Codestellation.Mailer.Templating.Razor;
using NUnit.Framework;

namespace Codestellation.Mailer.Tests.Templating.Razor
{
    [TestFixture]
    public class RazorMailTemplateEngineTests
    {
        private RazorMailTemplateEngine _engine;

        [SetUp]
        public void Setup()
        {
            _engine = RazorMailTemplateEngine.CreateUsingTemplatesFolder(@"Resources");

            //_engine = new RazorMailTemplateEngine(new Dictionary<Type, string>
            //    {
            //        {typeof (Foo), "@{Subject = \"This is foo subject\";}Hello, @Model.Name!"},
            //        {typeof (Bar), "@{Subject = \"This is bar subject\";}The bar value is @Model.Value"}
            //    });
        }

        [Test]
        public void Should_render_email_view_from_model_using_template()
        {
            MailView fooView = _engine.Render(new Foo {Name = "World"});
            Assert.That(fooView.Subject, Is.EqualTo("This is foo subject"));
            Assert.That(fooView.Body, Is.EqualTo("Hello, World!"));

            MailView barView = _engine.Render(new Bar {Value = 42});
            Assert.That(barView.Subject, Is.EqualTo("This is bar subject"));
            Assert.That(barView.Body, Is.EqualTo("The bar value is 42"));
        }
    }
}
