using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;

namespace Codestellation.Mailer.Transport
{
    public interface ISmtpClient
    {
        void Send(Email email);
    }
}
