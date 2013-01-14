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
            var compiler = new RazorTemplatesCompiler(TemplatesNamespaceName, typeof (DynamicRazorMailTemplate));
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
                template.SetOutput(writer);
                template.SetModel(mailModel);
                template.Execute();
            }

            return new MailView(template.Subject, builder.ToString());
        }

        //TODO: refactor this method
        public static RazorMailTemplateEngine CreateUsingTemplatesFolder(string folderPath)
        {
            if (Path.IsPathRooted(folderPath) == false)
            {
                string uriAssemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                string assemblyFolder = new Uri(uriAssemblyFolder).LocalPath;
                folderPath = Path.Combine(assemblyFolder, folderPath);
            }

            string[] templateFiles = Directory.GetFiles(folderPath, "*.cshtml", SearchOption.AllDirectories);

            var allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .ToList();

            Dictionary<Type, string> typeToTemplateMap = new Dictionary<Type, string>();

            foreach (var templateFile in templateFiles)
            {
                string templateName = Path.GetFileNameWithoutExtension(templateFile);

                 Type templateType = allTypes.FirstOrDefault(t => string.Equals(t.Name, templateName, StringComparison.CurrentCultureIgnoreCase));

                if (templateType != null)
                {
                    string templateContent = File.ReadAllText(templateFile);
                    typeToTemplateMap[templateType] = templateContent;
                }
            }
            
            return new RazorMailTemplateEngine(typeToTemplateMap);
        }
    }
}