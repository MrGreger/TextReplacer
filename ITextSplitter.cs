namespace TextReplacer
{
    internal interface ITextSplitter
    {
        List<ITextPart> SplitParts(List<ITextPart> parts);
    }
}