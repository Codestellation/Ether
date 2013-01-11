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

            _mailingListBroker =
                new MailingListBroker(
                    config.MailingRules
                          .Cast<MailingRuleConfigurationElement>()
                          .Select(
                              cfg =>
                              new MailingRule(cfg.Name,
                                              cfg.Recepients.Split(',').Select(r => r.Trim()).ToArray())) // TODO: move this into MailingRule class
                          .ToArray());

            _templateEngine = RazorMailTemplateEngine.CreateUsingTemplatesFolder(config.TemplatesFolder);
            return this;
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