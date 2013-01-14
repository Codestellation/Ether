using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public class MailingRule
    {
        public const string Any = "*";

        public string TypeHierarchy { get; private set; }

        public MailingList Recepients { get; private set; }

        public MailingRule(string typeHierarchy)
            : this(typeHierarchy, MailingList.Create())
        {
        }

        public MailingRule(string typeHierarchy, MailingList recepients)
        {
            TypeHierarchy = typeHierarchy;
            Recepients = recepients;
        }

        public bool Check(Type type)
        {
            if (String.Equals(TypeHierarchy, Any)) // any type
            {
                return true;
            }

            string[] hierarchyTokens = TypeHierarchy.Split('.');
            string[] typeNameTokens = type.FullName.Split('.');
            int hierarchyTokensCount = hierarchyTokens.Length;
            int typeNameTokensCount = typeNameTokens.Length;

            for (int i = 0; i < Math.Min(hierarchyTokensCount, typeNameTokensCount); i++)
            {
                string hierarchyToken = hierarchyTokens[i];

                if (String.Equals(hierarchyToken, Any))
                {
                    return true;
                }
                if (String.Equals(hierarchyToken, typeNameTokens[i], StringComparison.CurrentCultureIgnoreCase) == false)
                {
                    return false;
                }
            }

            if (hierarchyTokensCount > typeNameTokensCount && String.Equals(hierarchyTokens[typeNameTokensCount], Any) == false)
            {
                return false;
            }

            return true;
        }
    }
}