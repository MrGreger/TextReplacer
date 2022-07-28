using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReplacer
{
    internal class QuoutedText : ITextPart
    {
        public string Text { get; }

        public QuoutedText(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"QuotedText({Text})";
        }
    }
}
