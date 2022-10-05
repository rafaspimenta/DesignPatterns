using System.Text;

namespace Structural.Decorator
{
    public class CodeBuilder
    {
        private StringBuilder builder = new StringBuilder();
        private int indentLevel = 0;
        public CodeBuilder Indent()
        {
            indentLevel++;
            return this;
        }

        public StringBuilder Append(string value)
        {
            return builder.Append(value);
        }
        public StringBuilder AppendLine()
        {
            return builder.AppendLine();
        }

        public static implicit operator CodeBuilder(string s)
        {
            var cb = new CodeBuilder();
            cb.builder.Append(s);
            return cb;
        }

        public override string ToString()
        {
            return builder.ToString();
        }
    }
}