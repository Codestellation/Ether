using System;

namespace Codestellation.Ether.Templating.Razor
{
    public abstract class RazorMailTemplateBase
    {
        private RenderContext _context;

        public string Subject { get; protected set; }

        public string Layout { get; set; }

        public abstract void Execute();

        protected virtual void Write(object value)
        {
            _context.Write(value);
        }

        protected virtual void WriteLiteral(object value)
        {
            _context.Write(value);
        }

        public abstract void SetModel(object model);

        public void SetContext(RenderContext context)
        {
            _context = context;
        }

         public void DefineSection(string name, Action action)
         {
             _context.DefineSection(name, action);
         }

         public virtual string RenderSection(string name, bool isRequired = true)
         {
             return _context.RenderSection(name, isRequired);
         }

        public string RenderBody()
        {
            return _context.RenderBody();
        }
    }
}