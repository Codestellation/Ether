using Codestellation.Ether.Core;

namespace Codestellation.Ether.Templating.Razor
{
    public class RazorMailTemplateEngine : IMailTemplateEngine
    {
        private readonly RazorTemplatesFactory _templatesFactory;

        public RazorMailTemplateEngine(RazorTemplatesFactory templatesFactory)
        {
            _templatesFactory = templatesFactory;
        }
       
        public MailView Render(object mailModel)
        {
            string subject = null;
            string templateClassName = mailModel.GetType().Name;

            var context = new RenderContext();
            do
            {
                RazorMailTemplateBase template = _templatesFactory.Create(templateClassName);
                template.SetContext(context);
                template.SetModel(mailModel);
                template.Execute();

                if (string.IsNullOrEmpty(subject))
                {
                    subject = template.Subject;
                }

                context.Flush();
                templateClassName = template.Layout; // take next

            } while (string.IsNullOrEmpty(templateClassName) == false);

            string body = context.RenderBody();
            return new MailView(subject, body);
        }
    }
}