using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public class TestMailingListBroker : IMailingListBroker
    {
        private readonly Dictionary<Type, string[]> _mailingList;

        public TestMailingListBroker()
        {
            _mailingList = new Dictionary<Type, string[]>();
        }

        public TestMailingListBroker Register<T>(params string[] recepients)
        {
            _mailingList[typeof(T)] = recepients;
            return this;
        }

        public string[] GetRecepients(Type type)
        {
            return _mailingList[type];
        }
    }
}