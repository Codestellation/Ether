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

namespace Codestellation.Ether.Templating.Razor
{
    class RazorTemplatesCompiler
    {
        private const string LineX0TColX1TErrorX2Rn = "Line: {0}\t Col: {1}\t Error: {2}";

        private readonly string _templatesNamespaceName;
        private readonly RazorTemplateEngine _razorEngine;
        private readonly CompilerParameters _compilerParameters;

        public RazorTemplatesCompiler(string templatesNamespaceName, Type defaultTemplatesBaseClass)
        {
            _templatesNamespaceName = templatesNamespaceName;

            var razorHost = new RazorEngineHost(new CSharpRazorCodeLanguage())
                {
                    DefaultBaseClass = defaultTemplatesBaseClass.Name
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

        public Assembly Compile(Dictionary<Type, string> typeToTemplateMap, Func<Type, string> templateClassNameGenerator)
        {
            CodeCompileUnit[] codes = typeToTemplateMap
                .Select(map => GenerateTemplateCode(templateClassNameGenerator(map.Key),
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
        
        protected Assembly CompileTemplateCode(CodeCompileUnit[] generatedCodes)
        {
            using (var codeProvider = new CSharpCodeProvider())
            {
                DumpTemplatesCode(generatedCodes, codeProvider);

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

        // diagnostic method
        private static void DumpTemplatesCode(CodeCompileUnit[] generatedCodes, CSharpCodeProvider codeProvider)
        {
            for (int i = 0; i < generatedCodes.Length; i++)
            {
                using (var writer = new StreamWriter(string.Format("RazorTemplate{0}.cs", i), false, Encoding.UTF8))
                {
                    codeProvider.GenerateCodeFromCompileUnit(generatedCodes[i], writer, new CodeGeneratorOptions());
                }
            }
        }
    }
}