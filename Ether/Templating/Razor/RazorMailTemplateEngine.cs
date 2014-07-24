using System;
using Codestellation.Ether.Core;
using Codestellation.Ether.Misc;

namespace Codestellation.Ether.Templating.Razor
{
    public class RazorMailTemplateEngine : IMailTemplateEngine, IDisposable
    {
        private readonly RazorTemplatesFactory _templatesFactory;
        private readonly FolderChangedTrigger _folderChangedTrigger;

        public RazorMailTemplateEngine(RazorTemplatesFactory templatesFactory, bool autoReloadTemplates)
        {
            _templatesFactory = templatesFactory;

            if (autoReloadTemplates)
            {
                _folderChangedTrigger = new FolderChangedTrigger(templatesFactory.TemplatesFolderPath, "*.cshtml");
                _folderChangedTrigger.Attach(templatesFactory);
                _folderChangedTrigger.Start();
            }
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

        public void Dispose()
        {
            if (_folderChangedTrigger != null)
            {
                _folderChangedTrigger.Stop();
                _folderChangedTrigger.Dispose();
            }
        }
    }
}