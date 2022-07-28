using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReplacer.ReplacementsStorage
{
    public enum Gender
    {
        Male,
        Female
    }

    internal interface IReplacementCollection
    {

        string GetReplacement(Gender gender, string word);
        IReplacementCollection AddReplacement(string word, WordReplacement wordReplacement);
    }
}
