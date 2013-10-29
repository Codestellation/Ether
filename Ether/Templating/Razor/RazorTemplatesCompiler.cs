using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Razor;
using System.Web.Razor.Generator;
using Microsoft.CSharp;
using NLog;

namespace Codestellation.Ether.Templating.Razor
{
    class RazorTemplatesCompiler
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        private const string LineX0TColX1TErrorX2Rn = "Line: {0}\t Col: {1}\t Error: {2}";

        private readonly string _templatesNamespaceName;
        private readonly RazorTemplateEngine _razorEngine;
        private readonly CompilerParameters _compilerParameters;

        public RazorTemplatesCompiler(string templatesNamespaceName, Type defaultTemplatesBaseClass)
        {
            _templatesNamespaceName = templatesNamespaceName;

            var razorHost = new RazorEngineHost(new CSharpRazorCodeLanguage())
                {
                    DefaultBaseClass = defaultTemplatesBaseClass.Name,
                    GeneratedClassContext = new GeneratedClassContext("Execute", "Write", "WriteLiteral",
                                                                      "WriteTo", "WriteLiteralTo",
                                                                      null,
                                                                      "DefineSection")
                };

            string[] namespaces = new[]
                {
                    "System",
                    "System.Collections.Generic",
                    "System.Linq",
                    "System.Text"
                };
            foreach (var ns in namespaces)
            {
                razorHost.NamespaceImports.Add(ns);
            }

            _razorEngine = new RazorTemplateEngine(razorHost);

            string[] references = new[]
                {
                    "System.Core.dll",
                    "Microsoft.CSharp.dll"
                };

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            _compilerParameters = new CompilerParameters(assemblies
                                                                  .Where(x => !x.IsDynamic)
                                                                  .Where(a => !references.Contains(a.ManifestModule.Name))
                                                                  .Select(a => new Uri(a.CodeBase).LocalPath)
                                                                  .Distinct()
                                                                  .ToArray())
                {
                    GenerateInMemory = true
                };

            _compilerParameters.ReferencedAssemblies.AddRange(references);
        }

        public Assembly Compile(string[] templatesFilePath)
        {
            using (var codeProvider = new CSharpCodeProvider())
            {
                CodeCompileUnit[] codes = templatesFilePath
                    .Select(path => GenerateTemplateCode(
                        Path.GetFileNameWithoutExtension(path),
                        File.ReadAllText(path),
                        codeProvider))
                    .ToArray();

                return CompileTemplateCode(codes, codeProvider);
            }
        }

        protected CodeCompileUnit GenerateTemplateCode(string templateClassName, string templateContent, CSharpCodeProvider codeProvider)
        {
            using (var reader = new StringReader(templateContent))
            {
                GeneratorResults results = _razorEngine.GenerateCode(reader,
                                                                     templateClassName,
                                                                     _templatesNamespaceName,
                                                                     null);

                ThrowExceptionIfErrors(results);

                var code = results.GeneratedCode;
                DumpTemplateCode(templateClassName, code, codeProvider);
                Logger.Debug("Code generation for '{0}' completed", templateClassName);                
                return code;
            }
        }

        protected Assembly CompileTemplateCode(CodeCompileUnit[] generatedCodes, CSharpCodeProvider codeProvider)
        {
            CompilerResults results = codeProvider.CompileAssemblyFromDom(_compilerParameters, generatedCodes);
            ThrowExceptionIfErrors(results);

            Assembly assembly = results.CompiledAssembly;
            Logger.Debug("Compilation succeeded. Templates assembly: {0}", assembly);
            return assembly;
        }

        protected static void ThrowExceptionIfErrors(GeneratorResults results)
        {
            if (results.Success)
            {
                return;
            }
            throw new AggregateException(results
                                             .ParserErrors
                                             .Select(e => new Exception(string.Format(LineX0TColX1TErrorX2Rn,
                                                                                      e.Location.LineIndex,
                                                                                      e.Location.CharacterIndex,
                                                                                      e.Message))));
        }

        protected static void ThrowExceptionIfErrors(CompilerResults results)
        {
            CompilerErrorCollection errors = results.Errors;
            if (errors.HasErrors == false)
            {
                return;
            }

            throw new AggregateException("Razor template compilation errors",
                                         errors
                                             .OfType<CompilerError>()
                                             .Where(e => !e.IsWarning)
                                             .Select(e => new Exception(string.Format(LineX0TColX1TErrorX2Rn,
                                                                                      e.Line,
                                                                                      e.Column,
                                                                                      e.ErrorText))));
        }

        // diagnostic method
        private static void DumpTemplateCode(string templateName, CodeCompileUnit code, CSharpCodeProvider codeProvider)
        {
            var tepmlateSourceCodeFilePath = string.Format("Template-{0}.cs", templateName);
            using (var writer = new StreamWriter(tepmlateSourceCodeFilePath, false, Encoding.UTF8))
            {
                codeProvider.GenerateCodeFromCompileUnit(code, writer, new CodeGeneratorOptions());
            }
        }
    }
}