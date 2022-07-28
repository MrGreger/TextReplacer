// See https://aka.ms/new-console-template for more information
using TextReplacer;

foreach (var item in new QuotesSplitterSplitter().SplitParts(new List<string> { @" wtr ***""some text""4  *"" 234""* **""" }))
{
    Console.WriteLine(item);
}