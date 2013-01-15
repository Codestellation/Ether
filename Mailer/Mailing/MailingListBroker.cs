using System;
using System.Linq;

namespace Codestellation.Mailer.Mailing
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