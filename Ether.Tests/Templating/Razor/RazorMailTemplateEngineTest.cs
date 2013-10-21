using System;
using System.Linq;
using Codestellation.Ether.Core;
using Codestellation.Ether.Templating.Razor;
using NUnit.Framework;

namespace Codestellation.Ether.Tests.Templating.Razor
{
    [TestFixture]
    public class RazorMailTemplateEngineTests
    {
        private RazorMailTemplateEngine _engine;

        [SetUp]
        public void Setup()
        {
            _engine = RazorMailTemplateEngine.CreateUsingTemplatesFolder(@"Resources");
        }

        [Test]
        public void Should_render_template_with_strongly_typed_viewModel()
        {
            MailView fooView = Render(new Foo {Name = "World"});
            Assert.That(fooView.Subject, Is.EqualTo("This is foo subject"));
            Assert.That(fooView.Body, Is.EqualTo("Hello, World!"));
        }

        [Test]
        public void Should_render_template_with_dynamic_viewModel()
        {
            MailView barView = Render(new Bar { Value = 42 });
            Assert.That(barView.Subject, Is.EqualTo("This is bar subject"));
            Assert.That(barView.Body, Is.EqualTo("The bar value is 42"));
        }


        [Test]
        public void Should_render_template_with_layout()
        {
            MailView bazView = Render(new Baz());
            Assert.That(bazView.Subject, Is.EqualTo("This is baz subject"));
            Assert.That(bazView.Body, Is.EqualTo(Text("This is baz header", "This is baz body", "This is baz footer")));
        }
        
        MailView Render(object model)
        {
            MailView view = _engine.Render(model);
            view.Body = Trim(view.Body);
            return view;
        }

        static string Text(params string[] lines)
        {
            return string.Join(Environment.NewLine, lines);
        }
        static string Trim(string text)
        {
            return Text(text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Select(l=>l.Trim()).ToArray());
        }
    }
}