using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReplacer.TextParts
{
    internal class PlainText : ITextPart
    {
        public string Text { get; }

        public PlainText(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"PlainText({Text})";
        }
    }
}
