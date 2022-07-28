namespace TextReplacer
{
    internal interface ITextSplitter
    {
        List<string> SplitParts(List<string> parts);
    }
}