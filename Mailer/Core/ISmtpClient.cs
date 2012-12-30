using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public interface ISmtpClient
    {
        void Send(Email email);
    }
}
