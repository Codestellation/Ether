using System;
using System.Collections;
using System.Collections.Generic;

namespace Codestellation.Mailer.Core
{
    public class MailingList : IEnumerable<string>
    {
        private readonly HashSet<string> _addresses;

        public MailingList(params string[] addresses)
        {
            _addresses = new HashSet<string>(addresses,
                                             StringComparer.CurrentCultureIgnoreCase);
        }

        public MailingList UnionWith(MailingList another)
        {
            foreach (var address in another)
            {
                Add(address);
            }
            return this;
        }

        public MailingList Add(string address)
        {
            _addresses.Add(address);
            return this;
        }

        public static MailingList Parse(string addresses)
        {
            return new MailingList(addresses.SplitAndTrim());
        }

        public static MailingList Create(params string[] addresses)
        {
            return new MailingList(addresses);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _addresses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}