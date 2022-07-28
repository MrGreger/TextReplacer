using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReplacer
{
    internal class QuotesSplitterSplitter : ITextSplitter
    {
        public List<string> SplitParts(List<string> parts)
        {
            var result = new List<string>();

            foreach (var part in parts)
            {
                var partCursor = 0;
                do
                {

                    var parsedPart = ParseSimpleText(ref partCursor, part);
                    if (!string.IsNullOrEmpty(parsedPart))
                    {
                        result.Add(parsedPart);
                    }
                    parsedPart = ParseQuotes(ref partCursor, part);

                    if (!string.IsNullOrEmpty(parsedPart))
                    {
                        result.Add(parsedPart);
                    }

                    if (partCursor == part.Length)
                    {
                        break;
                    }
                } while (true);
            }

            return result;
        }

        private string ParseQuotes(ref int partCursor, string partToParse)
        {
            int quotesCount = 0;

            var parsedPart = string.Empty;

            for (int i = partCursor; i < partToParse.Length; i++)
            {
                if (partToParse[i] == '"')
                {
                    quotesCount++;
                }
                parsedPart += partToParse[i];
                partCursor++;

                if (quotesCount == 2)
                {
                    break;
                }
            }

            return parsedPart;
        }

        private static string ParseSimpleText(ref int partCursor, string partToParse)
        {
            var parsedPart = string.Empty;

            for (int i = partCursor; i < partToParse.Length; i++)
            {
                if (partToParse[i] == '"')
                {
                    break;
                }
                parsedPart += partToParse[i];
                partCursor++;
            }

            return parsedPart;
        }
    }
}
