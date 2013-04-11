﻿using System;
using System.Collections.Generic;

namespace Codestellation.Ether.Mailing
{
    public class TestMailingListBroker : IMailingListBroker
    {
        private readonly Dictionary<Type, MailingList> _mailingList;

        public TestMailingListBroker()
        {
            _mailingList = new Dictionary<Type, MailingList>();
        }

        public TestMailingListBroker Register<T>(params string[] recepients)
        {
            _mailingList[typeof(T)] = new MailingList(recepients);
            return this;
        }

        public MailingList GetRecepients(Type type)
        {
            return _mailingList[type];
        }
    }
}