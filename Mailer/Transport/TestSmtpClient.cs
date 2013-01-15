﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Core;

namespace Codestellation.Mailer.Transport
{
    public class TestSmtpClient : ISmtpClient
    {
        public ConcurrentQueue<Email> Outgoing { get; private set; }

        public TestSmtpClient()
        {
            Outgoing = new ConcurrentQueue<Email>();
        }

        public void Send(Email email)
        {
            Outgoing.Enqueue(email);
        }

        public Email GetNextOutgoing()
        {
            Email email;
            return Outgoing.TryDequeue(out email) ? email : null;
        }
    }
}