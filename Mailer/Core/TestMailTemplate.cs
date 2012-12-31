using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public class TestMailTemplate : IMailTemplate
    {
        private readonly Func<object, string> _renderSubject;
        private readonly Func<object, string> _renderBody;

        public TestMailTemplate(Func<object, string> renderSubject, Func<object, string> renderBody)
        {
            _renderSubject = renderSubject;
            _renderBody = renderBody;
        }

        public void RenderTo(object model, Email email)
        {
            email.Subject = _renderSubject(model);
            email.Body = _renderBody(model);
        }

        public static TestMailTemplate Create<T>(Func<T, string> renderSubject, Func<T, string> renderBody)
        {
            return new TestMailTemplate(m => renderSubject((T) m),
                                        m => renderBody((T) m));
        }
    }
}
