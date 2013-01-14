using System;

namespace Codestellation.Mailer.Core
{
    public interface IMailingListBroker
    {
        MailingList GetRecepients(Type type);
    }
}