using Codestellation.Ether.Core;

namespace Codestellation.Ether.Templating
{
    public interface IMailTemplateEngine
    {
        MailView Render(object mailModel);
    }
}