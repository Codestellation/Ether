namespace Codestellation.Mailer.Core
{
    public interface IMailTemplate
    {
        void Render(object model, out string subject, out string body);
    }
}