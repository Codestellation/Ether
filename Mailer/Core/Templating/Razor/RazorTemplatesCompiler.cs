using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Razor;
using Microsoft.CSharp;

namespace Codestellation.Mailer.Core.Templating.Razor
{
    class RazorTemplatesCompiler
    {
        private const string LineX0TColX1TErrorX2Rn = "Line: {0}\t Col: {1}\t Error: {2}";

        private readonly string _templatesNamespaceName;
        private readonly RazorTemplateEngine _razorEngine;
        private readonly Type _templateBaseType;
        private readonly CompilerParameters _compilerParameters;

        public RazorTemplatesCompiler(string templatesNamespaceName, Type templateBaseType)
        {
            _templatesNamespaceName = templatesNamespaceName;
            _templateBaseType = templateBaseType;
            RazorEngineHost razorHost = new RazorEngineHost(new CSharpRazorCodeLanguage())
            {
                DefaultBaseClass = templateBaseType.FullName,
            };

            razorHost.NamespaceImports.Add("System");
            razorHost.NamespaceImports.Add("System.Collections.Generic");
            razorHost.NamespaceImports.Add("System.Linq");
            razorHost.NamespaceImports.Add("System.Text");

            _razorEngine = new RazorTemplateEngine(razorHost);

            _compilerParameters = new CompilerParameters(new[]
                {
                    _templateBaseType.Assembly.CodeBase.Substring(8), //TODO: refactor this
                    "System.Core.dll",
                    "Microsoft.CSharp.dll"
                })
                {
                    GenerateInMemory = true
                };
        }

        public Assembly Compile(Dictionary<Type, string> typeToTemplateMap)
        {
            CodeCompileUnit[] codes = typeToTemplateMap
                .Select(map => GenerateTemplateCode(map.Key.Name,
                                                    map.Value))
                .ToArray();

            return CompileTemplateCode(codes);
        }

        protected CodeCompileUnit GenerateTemplateCode(string templateClassName, string templateContent)
        {
            using (var reader = new StringReader(templateContent))
            {
                GeneratorResults results = _razorEngine.GenerateCode(reader,
                                                                     templateClassName,
                                                                     _templatesNamespaceName,
                                                                     null);

                ThrowExceptionIfErrors(results);
                return results.GeneratedCode;
            }
        }
        
        protected Assembly CompileTemplateCode(params CodeCompileUnit[] generatedCodes)
        {
            using (var codeProvider = new CSharpCodeProvider())
            {
                //#if DEBUG
                //                using (var writer = new StreamWriter(@"razortemplate-out.cs", false, Encoding.UTF8))
                //                {
                //                    codeProvider.GenerateCodeFromCompileUnit(generatedCodes.First(), writer, new CodeGeneratorOptions());
                //                }
                //#endif

                CompilerResults results = codeProvider.CompileAssemblyFromDom(_compilerParameters, generatedCodes);
                ThrowExceptionIfErrors(results);
                return results.CompiledAssembly;
            }
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
    }
}