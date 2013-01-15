using System;
using System.Collections.Generic;
using Codestellation.Mailer.Core;

namespace Codestellation.Mailer.Templating
{
    public class MailTemplateEngine : IMailTemplateEngine
    {
        private readonly Dictionary<Type, Func<object, MailView>> _renders;

        public MailTemplateEngine()
        {
            _renders = new Dictionary<Type, Func<object, MailView>>();
        }

        public MailView Render(object mailModel)
        {
            return _renders[mailModel.GetType()](mailModel);
        }

        public MailTemplateEngine Register<T>(Func<T, MailView> render)
        {
            _renders[typeof (T)] = model => render((T) model);
            return this;
        }
    }
}