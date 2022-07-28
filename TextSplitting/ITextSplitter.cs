using TextReplacer.TextParts;

namespace TextReplacer.TextSplitting
{
    internal interface ITextSplitter
    {
        List<ITextPart> SplitParts(List<ITextPart> parts);
    }
}