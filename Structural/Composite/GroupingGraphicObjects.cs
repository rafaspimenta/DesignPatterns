using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural.Composite
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color;

        private readonly Lazy<List<GraphicObject>> children = new();
        public List<GraphicObject> Children => children.Value;

        public void Print(StringBuilder sb, int depth)
        {
            sb.Append(new String('*', depth))
                .Append(String.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
                .AppendLine($"{Name}");

            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }

}
