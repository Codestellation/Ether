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
        public string[] GetRecepients(Type type)
        {
            List<string> recepients = new List<string>();
            foreach (var rule in _rules)
            {
                if (rule.Check(type))
                {
                    recepients.AddRange(rule.Recepients);
                }
            }
            return recepients.Distinct().ToArray();
        }
    }
}