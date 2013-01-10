namespace Codestellation.Mailer.Core
{
    public interface IMailTemplateEngine
    {
        MailView Render(object mailModel);
    }
}