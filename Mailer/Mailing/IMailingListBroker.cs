using System;

namespace Codestellation.Mailer.Mailing
{
    public interface IMailingListBroker
    {
        MailingList GetRecepients(Type type);
    }
}