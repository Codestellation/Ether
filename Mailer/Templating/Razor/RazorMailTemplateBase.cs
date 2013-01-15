using System.IO;

namespace Codestellation.Mailer.Templating.Razor
{
    public abstract class RazorMailTemplateBase
    {
        protected TextWriter Output { get; private set; }

        public string Subject { get; protected set; }

        public abstract void Execute();

        protected virtual void Write(object value)
        {
            Output.Write(value);
        }

        protected virtual void WriteLiteral(object value)
        {
            Output.Write(value);
        }

        public abstract void SetModel(object model);

        public virtual void SetOutput(TextWriter output)
        {
            Output = output;
        }
    }
}