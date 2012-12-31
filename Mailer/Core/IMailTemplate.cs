namespace Codestellation.Mailer.Core
{
    public interface IMailTemplate
    {
        void RenderTo(object model, Email email);
    }
}