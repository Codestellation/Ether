using Codestellation.Mailer.Core;

namespace Codestellation.Mailer.Templating
{
    public interface IMailTemplateEngine
    {
        MailView Render(object mailModel);
    }
}