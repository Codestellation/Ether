using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codestellation.Mailer.Core
{
    public class MailingListBroker : IMailingListBroker
    {
        public string[] GetRecepients(Type type)
        {
            throw new NotImplementedException();
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