using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codestellation.Mailer.Core
{
    public class MailingListBroker : IMailingListBroker
    {
        private readonly MailingRule[] _rules;

        public MailingListBroker(params MailingRule[] rules)
        {
            _rules = rules;
        }

        //TODO: need cache proxy for this method
        public MailingList GetRecepients(Type type)
        {
            MailingList recepients = new MailingList();
            foreach (var rule in _rules.Where(rule => rule.Check(type)))
            {
                recepients.UnionWith(rule.Recepients);
            }
            return recepients;
        }
    }
}