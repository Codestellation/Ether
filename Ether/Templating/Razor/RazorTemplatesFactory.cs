﻿using System;
using System.IO;
using System.Reflection;
using Codestellation.Ether.Misc;
using NLog;

namespace Codestellation.Ether.Templating.Razor
{
    public class RazorTemplatesFactory : ITriggerHander
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        private const string TemplatesNamespaceName = "Codestellation.Ether.AutoGeneratedRazorTemplates";
        private readonly RazorTemplatesCompiler _compiler;
        private readonly string _templatesFolderPath;

        public string TemplatesFolderPath { get { return _templatesFolderPath; } }

        private Assembly _templatesAssembly;

        public RazorTemplatesFactory(string templatesFolderPath)
        {
            _templatesFolderPath = Utils.MakeRootedPath(templatesFolderPath);
            _compiler = new RazorTemplatesCompiler(TemplatesNamespaceName, typeof(DynamicRazorMailTemplate));
            ReloadTemplates();
        }

        public RazorMailTemplateBase Create(string templateClassName)
        {
            string templateTypeName = string.Format("{0}.{1}", TemplatesNamespaceName, templateClassName);
            var type = _templatesAssembly.GetType(templateTypeName, true);
            var template = (RazorMailTemplateBase)Activator.CreateInstance(type); // TODO: optimize
            return template;
        }

        public void ReloadTemplates()
        {
            Logger.Info("Reloading templates from '{0}'", _templatesFolderPath);
            string[] templateFiles = Directory.GetFiles(_templatesFolderPath, "*.cshtml", SearchOption.AllDirectories);
            _templatesAssembly = _compiler.Compile(templateFiles);

            int templatesCount = _templatesAssembly.GetExportedTypes().Length;
            Logger.Info("{0} templates reloaded", templatesCount);
        }

        public void OnTrigger()
        {
            ReloadTemplates();
        }
    }
}