﻿using System;
using System.Collections.Generic;
using Codestellation.Ether.Core;

namespace Codestellation.Ether.Templating
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
            Type modelType = mailModel.GetType();

            var rendererFunc = _renders[modelType];
            return rendererFunc(mailModel);
        }

        public MailTemplateEngine Register<T>(Func<T, MailView> render)
        {
            _renders[typeof (T)] = model => render((T) model);
            return this;
        }
    }
}