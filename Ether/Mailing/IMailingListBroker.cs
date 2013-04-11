using System;

namespace Codestellation.Ether.Mailing
{
    public interface IMailingListBroker
    {
        MailingList GetRecepients(Type type);
    }
}