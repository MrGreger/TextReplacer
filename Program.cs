// See https://aka.ms/new-console-template for more information
using TextReplacer;

var testString = @"лол. Лол. лОл лолText, ""я цитата"" лол лолText """;

var parts = new QuotesSplitterSplitter().SplitParts(new List<ITextPart> { new PlainText(testString) });

Console.WriteLine("До:");

foreach (var item in parts)
{
    Console.Write(item.Text);
}
Console.WriteLine();
Console.WriteLine(new string('-', 50));

Console.WriteLine("После:");

var replacements = new InMemoryReplacementDictionary();

replacements.AddReplacement("лол", new WordReplacement("кек", "кекушка"));
replacements.AddReplacement("цитата", new WordReplacement("цитат", "цитатка"));

var replacer = new SimpleTextReplacer(replacements);

var result = replacer.ReplaceTextInParts(Gender.Male, parts);

foreach (var item in result)
{
    Console.Write(item.Text);
}
Console.WriteLine();
Console.WriteLine(new string('-', 50));

Console.WriteLine("После (жен):");

result = replacer.ReplaceTextInParts(Gender.Female, parts);

foreach (var item in result)
{
    Console.Write(item.Text);
}
Console.WriteLine();
Console.WriteLine(new string('-', 50));