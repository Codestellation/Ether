using System.IO;

namespace Codestellation.Mailer.Core.Templating.Razor
{
    public abstract class RazorMailTemplateBase
    {
        public TextWriter Output { get; set; }

        public dynamic Model { get; set; }

        public string Subject { get; set; }

        public abstract void Execute();

        protected virtual void Write(object value)
        {
            Output.Write(value);
        }

        protected virtual void WriteLiteral(object value)
        {
            Output.Write(value);
        }
    }
}