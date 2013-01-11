using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Mailer.Config;
using Codestellation.Mailer.Core;
using Codestellation.Mailer.Core.Templating.Razor;

namespace Codestellation.Mailer.Bootstrap
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
            var config = MailNotifierConfigSection.Instance;

            _fromAddress = config.FromAddress;

            Dictionary<string, string[]> groups = config.MailingGroups
                                                        .Cast<GroupConfigElement>()
                                                        .ToDictionary(g => g.Name,
                                                                      g => g.Participants.SplitAndTrim());

            _mailingListBroker =
                new MailingListBroker(
                    config.MailingRules
                          .Cast<MailingRuleConfigurationElement>()
                          .Select(
                              cfg =>
                              new MailingRule(cfg.Name,
                                              BuildRecepientsList(cfg.Recepients.SplitAndTrim(), groups)))
                        
                          .ToArray());

            _templateEngine = RazorMailTemplateEngine.CreateUsingTemplatesFolder(config.TemplatesFolder);
            return this;
        }

        static string[] BuildRecepientsList(string[] recepients, Dictionary<string, string[]> groups) // TODO: move this into MailingRule class
        {
            List<string> result = new List<string>();
            foreach (var recepient in recepients)
            {
                if (groups.ContainsKey(recepient)) // group?
                {
                    result.AddRange(groups[recepient]);
                }
                else
                {
                    result.Add(recepient);
                }
            }
            return result.Distinct().ToArray();
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