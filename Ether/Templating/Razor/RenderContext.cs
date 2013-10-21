using System;
using System.Collections.Generic;
using System.Text;

namespace Codestellation.Ether.Templating.Razor
{
    public class RenderContext
    {
        public const int DefaultCapacity = 2048;

        private  Dictionary<string, Action> _sections;
        private  Dictionary<string, Action> Sections
        {
            get { return _sections ?? (_sections = new Dictionary<string, Action>()); }
        }

        private Stack<StringBuilder> _state;
        private Stack<StringBuilder> State
        {
            get { return _state ?? (_state = new Stack<StringBuilder>()); }
        }

        private StringBuilder _buffer;
        private string _body;
        
        public RenderContext()
        {
            _buffer = new StringBuilder(DefaultCapacity);
        }

        public void Write(object value)
        {
            _buffer.Append(value);
        }

        public void DefineSection(string name, Action action)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "Section name is required");
            }
            if (Sections.ContainsKey(name))
            {
                throw new ArgumentException(string.Format("Section '{0}' already defined", name), "name");
            }
            Sections.Add(name, action);
        }

        public string RenderSection(string name, bool isRequired)
        {
            Action sectionRender;

            if (!Sections.TryGetValue(name, out sectionRender))
            {
                if (isRequired)
                {
                    throw new ArgumentException(string.Format("Undefine section name '{0}'", name));
                }
                return null;
            }

            State.Push(_buffer); // save
            _buffer = new StringBuilder(DefaultCapacity);
            sectionRender();
            string sectionContent = _buffer.ToString();
            _buffer = State.Pop(); // restore
            return sectionContent;
        }

        public string RenderBody()
        {            
            return _body;
        }

        public void Flush()
        {
            _body = _buffer.ToString();
            _buffer.Clear();
        }
    }
}