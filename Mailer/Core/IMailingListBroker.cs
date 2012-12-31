using System;

namespace Codestellation.Mailer.Core
{
    public interface IMailingListBroker
    {
        string[] GetRecepients(Type type);
    }
}