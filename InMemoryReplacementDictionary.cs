using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReplacer
{
    internal partial class InMemoryReplacementDictionary : IReplacementCollection
    {
        private Dictionary<string, WordReplacement> _replacementDictionary = new Dictionary<string, WordReplacement>();

        public IReplacementCollection AddReplacement(string word, WordReplacement wordReplacement)
        {
            _replacementDictionary.TryAdd(word, wordReplacement);
            return this;
        }

        public string GetReplacement(Gender gender, string word)
        {
            if(!_replacementDictionary.TryGetValue(word, out var replacement))
            {
                return null;
            }

            return replacement.GetReplacement(gender);
        }
    }
}
