namespace Codestellation.Mailer
{
    public interface IMailNotifier
    {
        void Send(object mail);
    }
}