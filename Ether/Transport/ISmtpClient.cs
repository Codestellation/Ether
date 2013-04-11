using Codestellation.Ether.Core;

namespace Codestellation.Ether.Transport
{
    public interface ISmtpClient
    {
        void Send(Email email);
    }
}
