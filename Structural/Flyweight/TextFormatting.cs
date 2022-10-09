using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Flyweight
{
    public class FormattedText
    {
        private readonly string plainText;
        private readonly List<TextRange> formatting = new();

        public FormattedText(string plainText)
        {
            this.plainText = plainText;
        }
        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange { Start = start, End = end };
            formatting.Add(range);
            return range;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (var range in formatting)
                    if (range.Covers(i) && range.Capitalize)
                        c = char.ToUpperInvariant(c);
                sb.Append(c);
            }
            return sb.ToString();
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize; // also Bold, Italic, etc.
            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }
    }
}
