﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Codestellation.Mailer.Core.Templating.Razor
{
    public class RazorMailTemplateEngine : IMailTemplateEngine
    {
        private const string TemplatesNamespaceName = "Codestellation.AutoGeneratedRazorTemplates";

        private readonly Assembly _templatesAssembly;

        public RazorMailTemplateEngine(Dictionary<Type, string> typeToTemplateMap)
        {
            var compiler = new RazorTemplatesCompiler(TemplatesNamespaceName, typeof (RazorMailTemplateBase));
            _templatesAssembly = compiler.Compile(typeToTemplateMap);
        }

        public MailView Render(object mailModel)
        {
            string templateTypeName = string.Format("{0}.{1}", TemplatesNamespaceName, mailModel.GetType().Name);
            var type = _templatesAssembly.GetType(templateTypeName, true);

            var template = Activator.CreateInstance(type) as RazorMailTemplateBase; // TODO: cache this

            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                template.Output = writer;
                template.Model = mailModel;
                template.Execute();
            }

            return new MailView(template.Subject, builder.ToString());
        }
    }
}