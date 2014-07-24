using System.Collections.Generic;
using System.Linq;
using Codestellation.Ether.Config;
using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Misc;
using Codestellation.Ether.Templating;
using Codestellation.Ether.Templating.Razor;
using Codestellation.Ether.Transport;

namespace Codestellation.Ether.Bootstrap
{
    public class MailNotifierBuilder
    {
        private string _fromAddress;
        private IQueue _outgoingQueue;
        private IMailingListBroker _mailingListBroker;
        private IMailTemplateEngine _templateEngine;
        private int _sendersPoolSize;
        private IEmailSender[] _emailSenders;

        public MailNotifierBuilder FromConfig()
        {
            var config = EtherConfigSection.Instance;
            
            _fromAddress = config.FromAddress;
            _sendersPoolSize = config.PoolSize;

            string outgoingEmailsFolder = config.OutgoingEmailsFolder;
            if (string.IsNullOrEmpty(outgoingEmailsFolder))
            {
                _outgoingQueue = new TransientQueue();
            }
            else
            {
                _outgoingQueue = new PersistentQueue("OutgoingEmails", outgoingEmailsFolder);
            }

            Dictionary<string, MailingList> groups = config.MailingGroups
                .Cast<GroupConfigElement>()
                .ToDictionary(g => g.Name,
                    g => MailingList.Parse(g.Participants));

            _mailingListBroker =
                new MailingListBroker(
                    config.MailingRules
                        .Cast<MailingRuleConfigurationElement>()
                        .Select(
                            cfg =>
                                new MailingRule(cfg.Name,
                                    BuildMailingList(cfg.Recepients.SplitAndTrim(), groups)))
                        
                        .ToArray());

            var templatesFactory = new RazorTemplatesFactory(config.TemplatesFolder);
            _templateEngine = new RazorMailTemplateEngine(templatesFactory, config.AutoReloadTemplates);

            _emailSenders = new IEmailSender[_sendersPoolSize];
            for (int i = 0; i < _sendersPoolSize; i++)
            {
                _emailSenders[i] = new SmtpSender();
            }

            return this;
        }

        static MailingList BuildMailingList(string[] recepients, Dictionary<string, MailingList> groups) // TODO: move this into MailingRule class
        {
            MailingList list = new MailingList();
            foreach (var recepient in recepients)
            {
                if (groups.ContainsKey(recepient)) // group?
                {
                    list.UnionWith(groups[recepient]);
                }
                else
                {
                    list.Add(recepient);
                }
            }
            return list;
        }

        public IMailNotifier Build()
        {
            var notifier = new MailNotifier(
                _fromAddress,
                _outgoingQueue, 
                _mailingListBroker,
                _templateEngine, 
                _emailSenders);

            return notifier;
        }
    }
}