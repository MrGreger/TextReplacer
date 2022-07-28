using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextReplacer
{
    internal class SimpleTextReplacer
    {
        private IReplacementCollection _replacementCollection;

        public SimpleTextReplacer(IReplacementCollection replacementCollection)
        {
            _replacementCollection = replacementCollection;
        }

        public List<ITextPart> ReplaceTextInParts(Gender gender, List<ITextPart> parts)
        {
            var result = new List<ITextPart>();

            foreach (var part in parts)
            {
                if (part is PlainText plainText)
                {
                    var replacedText = ReplacePlainText(gender, plainText);

                    result.Add(new PlainText(replacedText));
                }
                else
                {
                    result.Add(part);
                }
            }

            return result;
        }

        private string ReplacePlainText(Gender gender, PlainText plainText)
        {
            var text = plainText.Text;

            var wordsToReplace = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var replacedWords = new HashSet<string>();

            foreach (var word in wordsToReplace)
            {
                var trimmedWord = word.Trim().ToLower();

                if (replacedWords.Contains(trimmedWord))
                {
                    continue;
                }

                var wordToReplace = _replacementCollection.GetReplacement(gender, trimmedWord);
                if (string.IsNullOrEmpty(wordToReplace))
                {
                    continue;
                }

                text = Regex.Replace(text, $"\\b{word}\\b", x =>
                {
                    var resultingWord = string.Empty;

                    for (int i = 0; i < wordToReplace.Length; i++)
                    {
                        if (x.Value.Length > i)
                        {
                            resultingWord += char.IsUpper(x.Value[i]) ? char.ToUpper(wordToReplace[i]) : wordToReplace[i];
                        }
                        else
                        {
                            resultingWord += wordToReplace[i];
                        }
                    }

                    return resultingWord;
                }, RegexOptions.IgnoreCase);

                replacedWords.Add(trimmedWord);
            }

            return text;
        }
    }
}
