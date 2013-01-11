using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    //TODO: move IsTypeInHierarchy metod here

    public class MailingRule
    {
        public string TypeHierarchy { get; private set; }

        public string[] Recepients { get; set; }

        public MailingRule(string typeHierarchy, params string[] recepients)
        {
            TypeHierarchy = typeHierarchy;
            Recepients = recepients.Distinct().ToArray();
        }
    }
}