﻿using System.Collections.Generic;
using System.Linq;
using Codestellation.Ether.Config;
using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Templating;
using Codestellation.Ether.Templating.Razor;
using Codestellation.Ether.Transport;

namespace Codestellation.Ether.Bootstrap
{
    public static class Create
    {
        public static MailNotifierBuilder MailNotifier()
        {
            return new MailNotifierBuilder();
        }
    }

    public class MailNotifierBuilder
    {
        private string _fromAddress;
        private ISmtpClient _smtpClient;
        private IMailingListBroker _mailingListBroker;
        private IMailTemplateEngine _templateEngine;


        public MailNotifierBuilder()
        {
            _smtpClient = new SmtpClient();
        }

        public MailNotifierBuilder FromConfig()
        {
            var config = EtherConfigSection.Instance;

            _fromAddress = config.FromAddress;

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

            _templateEngine = RazorMailTemplateEngine.CreateUsingTemplatesFolder(config.TemplatesFolder);
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
            return new MailNotifier(_fromAddress,
                                    _smtpClient,
                                    _mailingListBroker,
                                    _templateEngine);
        }
    }
}