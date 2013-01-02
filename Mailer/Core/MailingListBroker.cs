using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codestellation.Mailer.Core
{
    public class MailingListBroker : IMailingListBroker
    {
        private Dictionary<string, string[]> _subscriptions;

        public MailingListBroker()
        {
            _subscriptions = new Dictionary<string, string[]>();
        }

        public string[] GetRecepients(Type type)
        {
            List<string> recepients = new List<string>();
            foreach (var subscription in _subscriptions)
            {
                if(IsTypeInHierarchy(type, subscription.Key))
                {
                    recepients.AddRange(subscription.Value);
                }
            }
            return recepients.Distinct().ToArray();
        }

        public void Register(string typeHierarchy, params string[] recepients)
        {
            _subscriptions[typeHierarchy] = recepients;
        }

        public static bool IsTypeInHierarchy(Type type, string hierarchy)
        {
            if (String.Equals(hierarchy, "*")) // any type
            {
                return true;
            }

            string[] hierarchyTokens = hierarchy.Split('.');
            string[] typeNameTokens = type.FullName.Split('.');
            int hierarchyTokensCount = hierarchyTokens.Length;
            int typeNameTokensCount = typeNameTokens.Length;

            for (int i = 0; i < Math.Min(hierarchyTokensCount, typeNameTokensCount); i++)
            {
                string hierarchyToken = hierarchyTokens[i];

                if (String.Equals(hierarchyToken, "*"))
                {
                    return true;
                }
                if (String.Equals(hierarchyToken, typeNameTokens[i], StringComparison.CurrentCultureIgnoreCase) == false)
                {
                    return false;
                }
            }

            if (hierarchyTokensCount > typeNameTokensCount && String.Equals(hierarchyTokens[typeNameTokensCount], "*") == false)
            {
                return false;
            }

            return true;
        }
    }
}