using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public class TestMailTemplateConainer : IMailTemplateConainer
    {
        private readonly Dictionary<Type, IMailTemplate> _templates;

        public TestMailTemplateConainer()
        {
            _templates = new Dictionary<Type, IMailTemplate>();
        }

        public IMailTemplate Get(Type mailType)
        {
            return _templates[mailType];
        }

        public TestMailTemplateConainer Register<T>(Func<T, string> renderSubject, Func<T, string> renderBody)
        {
            _templates[typeof (T)] = TestMailTemplate.Create(renderSubject, renderBody);
            return this;
        }
    }
}