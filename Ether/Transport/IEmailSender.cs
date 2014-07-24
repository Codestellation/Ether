using System.ComponentModel;
using Codestellation.Ether.Core;

namespace Codestellation.Ether.Transport
{
    public interface IEmailSender
    {
        void SendAsync(Email email);

        event AsyncCompletedEventHandler Completed;
    }
}